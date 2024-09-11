using Moq;
using CarMechanic.Shared;
using CarMechanic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarMechanic.Test;

public class CustomerServiceTests
{
    [Fact]
    public async Task CreateCustomer_SuccessfullyAddsCustomer()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CustomerService>>();
        var mockContext = new Mock<CarMechanicContext>();
        var mockSet = new Mock<DbSet<Customer>>();
        
        mockContext.Setup(m => m.Customers).Returns(mockSet.Object);
        mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        
        var service = new CustomerService(mockLogger.Object, mockContext.Object);
        var customer = new Customer 
        { 
            Ugyfelszam = Guid.NewGuid(), 
            Nev = "John Doe", 
            Email = "john@example.com", 
            Lakcim = "1234 Street" 
        };

        // Act
        await service.CreateCustomer(customer);

        // Assert
        mockSet.Verify(m => m.AddAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()), Times.Once());
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }
    [Fact]
    public async Task DeleteCustomer_RemovesCustomerSuccessfully()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CustomerService>>();
        var mockContext = new Mock<CarMechanicContext>();
        var service = new CustomerService(mockLogger.Object, mockContext.Object);
        var customerId = Guid.NewGuid();
        var customer = new Customer 
        { 
            Ugyfelszam = customerId, 
            Nev = "Bob", 
            Email = "bob@example.com", 
            Lakcim = "9876 Road" 
        };
        mockContext.Setup(m => m.Customers.FindAsync(customerId)).ReturnsAsync(customer);

        // Act
        await service.DeleteCustomer(customerId);

        // Assert
        mockContext.Verify(m => m.Customers.Remove(customer), Times.Once());
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
    }

    [Fact]
    public async Task GetCustomer_ReturnsCorrectCustomer()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CustomerService>>();
        var mockContext = new Mock<CarMechanicContext>();
        var service = new CustomerService(mockLogger.Object, mockContext.Object);
        var customerId = Guid.NewGuid();
        var customer = new Customer 
        { 
            Ugyfelszam = customerId, 
            Nev = "Alice", 
            Email = "alice@example.com", 
            Lakcim = "5678 Avenue" 
        };

        mockContext.Setup(m => m.Customers.FindAsync(customerId)).ReturnsAsync(customer);

        // Act
        var result = await service.GetCustomer(customerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(customerId, result.Ugyfelszam);
        Assert.Equal("Alice", result.Nev);
        Assert.Equal("alice@example.com", result.Email);
        Assert.Equal("5678 Avenue", result.Lakcim);
    }

    [Fact]
    public async Task UpdateCustomer_UpdatesCustomerDetailsSuccessfully()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CustomerService>>();
        var mockContext = new Mock<CarMechanicContext>();
        var service = new CustomerService(mockLogger.Object, mockContext.Object);
        var customerId = Guid.NewGuid();
        var existingCustomer = new Customer 
        { 
            Ugyfelszam = customerId, 
            Nev = "Old Name", 
            Email = "old@example.com", 
            Lakcim = "Old Address" 
        };
        var newCustomer = new Customer 
        { 
            Ugyfelszam = customerId, 
            Nev = "New Name", 
            Email = "new@example.com", 
            Lakcim = "New Address" 
        };
        mockContext.Setup(m => m.Customers.FindAsync(customerId)).ReturnsAsync(existingCustomer);

        // Act
        await service.UpdateCustomer(newCustomer);

        // Assert
        Assert.Equal("New Name", existingCustomer.Nev);
        Assert.Equal("new@example.com", existingCustomer.Email);
        Assert.Equal("New Address", existingCustomer.Lakcim);
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
    }
    
}
