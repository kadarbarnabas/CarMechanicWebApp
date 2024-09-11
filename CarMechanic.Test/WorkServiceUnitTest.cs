using System.Threading.Tasks;
using CarMechanic;
using CarMechanic.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CarMechanic.Test;
public class WorkServiceTests
{

    [Fact]
    public async Task CreateWork_AddsNewEntry()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<WorkService>>();
        var mockContext = new Mock<CarMechanicContext>();
        var dbSetMock = new Mock<DbSet<Work>>();
        mockContext.Setup(m => m.Works).Returns(dbSetMock.Object);
        var service = new WorkService(mockLogger.Object, mockContext.Object);
        var work = new Work 
        { 
            MunkaId = Guid.NewGuid(),
            Ugyfelszam = "123123", 
            Rendszam = "ABC-123", 
            GyartasiEv = 2015, 
            Kategoria = "Motor", 
            HibakLeirasa = "A motor nem indul", 
            HibaSulyossag = 7, 
            Allapot = "Felvett Munka", 
        };

        // Act
        await service.CreateWork(work);

        // Assert
        dbSetMock.Verify(m => m.AddAsync(It.IsAny<Work>(), It.IsAny<CancellationToken>()), Times.Once);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteWork_RemovesExistingEntry()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<WorkService>>();
        var mockContext = new Mock<CarMechanicContext>();
        var dbSetMock = new Mock<DbSet<Work>>();
        mockContext.Setup(m => m.Works).Returns(dbSetMock.Object);
        var service = new WorkService(mockLogger.Object, mockContext.Object);
        var workId = Guid.NewGuid();
        var work = new Work { MunkaId = workId };
        dbSetMock.Setup(m => m.FindAsync(workId)).ReturnsAsync(work);

        // Act
        await service.DeleteWork(workId);

        // Assert
        dbSetMock.Verify(m => m.Remove(work), Times.Once);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetWork_RetrievesWorkById()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<WorkService>>();
        var mockContext = new Mock<CarMechanicContext>();
        var service = new WorkService(mockLogger.Object, mockContext.Object);
        var workId = Guid.NewGuid();
        var work = new Work { MunkaId = workId };
        mockContext.Setup(m => m.Works.FindAsync(workId)).ReturnsAsync(work);

        // Act
        var result = await service.GetWork(workId);

        // Assert
        Assert.Equal(workId, result.MunkaId);
    }

    [Fact]
    public async Task UpdateWork_ModifiesExistingEntry()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<WorkService>>();
        var mockContext = new Mock<CarMechanicContext>();
        var dbSetMock = new Mock<DbSet<Work>>();
        mockContext.Setup(m => m.Works).Returns(dbSetMock.Object);
        var service = new WorkService(mockLogger.Object, mockContext.Object);
        var id = Guid.NewGuid();
        var existingWork = new Work 
        { 
            MunkaId = id,
            Ugyfelszam = "123123", 
            Rendszam = "ABC-123", 
            GyartasiEv = 2015, 
            Kategoria = "Motor", 
            HibakLeirasa = "A motor nem indul", 
            HibaSulyossag = 7, 
            Allapot = "Felvett Munka", 
        };
        var newWork = new Work 
        { 
            MunkaId = id,
            Ugyfelszam = "123123", 
            Rendszam = "ABC-123", 
            GyartasiEv = 2018, 
            Kategoria = "Motor", 
            HibakLeirasa = "A motor nem indul", 
            HibaSulyossag = 7, 
            Allapot = "Felvett Munka", 
        };
        dbSetMock.Setup(m => m.FindAsync(existingWork.MunkaId)).ReturnsAsync(existingWork);

        // Act
        await service.UpdateWork(newWork);

        // Assert
        dbSetMock.Verify(m => m.FindAsync(existingWork.MunkaId), Times.Once);
        Assert.Equal(newWork.Ugyfelszam, existingWork.Ugyfelszam);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}