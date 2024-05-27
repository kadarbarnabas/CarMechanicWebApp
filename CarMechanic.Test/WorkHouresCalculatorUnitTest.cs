using System.Threading.Tasks;
using CarMechanic;
using CarMechanic.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CarMechanic.Test;
public class WorkHouresCalculatorUnitTest
{   
    [Fact]
    public void calculateWorkHours_forNewCar_withMinorSeverity()
    {
        // Arrange
        var calculator = new WorkHouresCalculator();
        string kategoria = "Motor";
        int gyartasiEv = DateTime.Now.Year; // New car
        int hibaSulyossag = 2; // Minor severity

        // Act
        int result = calculator.CalculateWorkHours(kategoria, gyartasiEv, hibaSulyossag);

        // Assert
        Assert.Equal(1, result); // Expected work hours = 8 * 0.5 * 0.2 = 0.8, rounded to 1
    }

    [Fact]
    public void throw_exception_for_unknown_category()
    {
        // Arrange
        var calculator = new WorkHouresCalculator();
        string kategoria = "UnknownCategory";
        int gyartasiEv = 2010;
        int hibaSulyossag = 5;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => calculator.CalculateWorkHours(kategoria, gyartasiEv, hibaSulyossag));
    }

    [Fact]
    public void calculate_work_hours_for_old_car_with_maximum_severity()
    {
        // Arrange
        var calculator = new WorkHouresCalculator();
        string kategoria = "Motor";
        int gyartasiEv = DateTime.Now.Year - 25; // Old car
        int hibaSulyossag = 10; // Maximum severity

        // Act
        int result = calculator.CalculateWorkHours(kategoria, gyartasiEv, hibaSulyossag);

        // Assert
        Assert.Equal(16, result); // Expected work hours = 8 * 2 * 1 = 16
    }

    [Fact]
    public void calculate_work_hours_for_mid_aged_car_with_moderate_severity()
    {
        // Arrange
        var calculator = new WorkHouresCalculator();
        string kategoria = "Motor";
        int gyartasiEv = DateTime.Now.Year - 5; // Mid-aged car
        int hibaSulyossag = 5; // Moderate severity

        // Act
        int result = calculator.CalculateWorkHours(kategoria, gyartasiEv, hibaSulyossag);

        // Assert
        Assert.Equal(5, result); // Expected work hours = 8 * 1 * 0.6 = 4.8, rounded to 24
    }

    [Fact]
    public void calculate_work_hours_for_different_categories()
    {
        // Arrange
        var calculator = new WorkHouresCalculator();
        
        // Act & Assert for 'Motor' category
        string kategoria = "Motor";
        int gyartasiEv = DateTime.Now.Year - 5; // Car is 5 years old
        int hibaSulyossag = 3; // Medium severity
        int resultMotor = calculator.CalculateWorkHours(kategoria, gyartasiEv, hibaSulyossag);
        Assert.Equal(3, resultMotor); 
        
        // Act & Assert for 'Karosszéria' category
        kategoria = "Karosszéria";
        gyartasiEv = DateTime.Now.Year - 15; // Car is 15 years old
        hibaSulyossag = 8; // High severity
        int resultKarosszeria = calculator.CalculateWorkHours(kategoria, gyartasiEv, hibaSulyossag);
        Assert.Equal(4, resultKarosszeria); 
        
        // Act & Assert for 'Futómű' category
        kategoria = "Futómű";
        gyartasiEv = DateTime.Now.Year - 10; // Car is 10 years old
        hibaSulyossag = 5; // Medium severity
        int resultFutomu = calculator.CalculateWorkHours(kategoria, gyartasiEv, hibaSulyossag);
        Assert.Equal(5, resultFutomu); 
        
        // Act & Assert for 'Fékberendezés' category
        kategoria = "Fékberendezés";
        gyartasiEv = DateTime.Now.Year - 8; // Car is 8 years old
        hibaSulyossag = 10; // Maximum severity
        int resultFekberendezes = calculator.CalculateWorkHours(kategoria, gyartasiEv, hibaSulyossag);
        Assert.Equal(4, resultFekberendezes); 
    }
}