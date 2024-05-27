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

namespace CarMechanic.Test
{
    public class WorkServiceTests
    {
        private readonly Mock<CarMechanicContext> _mockContext;
        private readonly Mock<ILogger<WorkService>> _mockLogger;
        private readonly WorkService _service;

        public WorkServiceTests()
        {
            _mockContext = new Mock<CarMechanicContext>(new DbContextOptions<CarMechanicContext>());
            _mockLogger = new Mock<ILogger<WorkService>>();
            _service = new WorkService(_mockLogger.Object, _mockContext.Object);
        }
        [Fact]
        public async Task CreateWork_ShouldAddWork()
        {
            // Arrange
            var work = new Work
            {
                MunkaId = Guid.NewGuid(),
                Ugyfelszam = "1234",
                Rendszam = "ABC-123",
                GyartasiEv = 2020,
                Kategoria = "Motor",
                HibakLeirasa = "Engine not starting",
                HibaSulyossag = 5,
                Allapot = "Felvett Munka"
            };

            _mockContext.Setup(c => c.Works.AddAsync(It.IsAny<Work>(), default))
                .ReturnsAsync((EntityEntry<Work>)null);

            _mockContext.Setup(c => c.SaveChangesAsync(default))
                .ReturnsAsync(1);

            // Act
            await _service.CreateWork(work);

            // Assert
            _mockContext.Verify(c => c.Works.AddAsync(It.Is<Work>(w => w == work), default), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
        
        [Fact]
        public async Task DeleteWork_ShouldRemoveWork()
        {
            // Arrange
            var work = new Work
            {
                MunkaId = Guid.NewGuid(),
                Ugyfelszam = "1234",
                Rendszam = "ABC-123",
                GyartasiEv = 2020,
                Kategoria = "Karosszéria",
                HibakLeirasa = "Scratch on door",
                HibaSulyossag = 3,
                Allapot = "Felvett Munka"
            };

            _mockContext.Setup(c => c.Works.FindAsync(work.MunkaId)).ReturnsAsync(work);

            // Act
            var result = await _service.GetWork(work.MunkaId);
            await _service.DeleteWork(result.MunkaId);

            // Assert
            _mockContext.Verify(c => c.Works.Remove(work), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
        
        [Fact]
        public async Task GetWork_ShouldReturnWork()
        {
            // Arrange
            var workId = Guid.NewGuid();
            var work = new Work
            {
                MunkaId = workId,
                Ugyfelszam = "1234",
                Rendszam = "ABC-123",
                GyartasiEv = 2020,
                Kategoria = "Karosszéria",
                HibakLeirasa = "Scratch on door",
                HibaSulyossag = 3,
                Allapot = "Felvett Munka"
            };

            _mockContext.Setup(c => c.Works.FindAsync(workId)).ReturnsAsync(work);

            // Act
            var result = await _service.GetWork(workId);

            // Assert
            Assert.Equal(work, result);
        }

        [Fact]
        public async Task UpdateWork_ModifiesExistingRecord()
        {
            // Arrange
            var existingWork = new Work
            {
                MunkaId = Guid.NewGuid(),
                Ugyfelszam = "5678",
                Rendszam = "XYZ-987",
                GyartasiEv = 2018,
                Kategoria = "Fenntartás",
                HibakLeirasa = "Oil change",
                HibaSulyossag = 2,
                Allapot = "In Progress"
            };

            var updatedWork = new Work
            {
                MunkaId = existingWork.MunkaId,
                Ugyfelszam = "9876",
                Rendszam = "LMN-456",
                GyartasiEv = 2019,
                Kategoria = "Motor",
                HibakLeirasa = "Engine noise",
                HibaSulyossag = 4,
                Allapot = "Completed"
            };

            _mockContext.Setup(c => c.Works.FindAsync(existingWork.MunkaId)).ReturnsAsync(existingWork);

            // Act
            await _service.UpdateWork(updatedWork);

            // Assert
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
            Assert.Equal(updatedWork.Ugyfelszam, existingWork.Ugyfelszam);
            Assert.Equal(updatedWork.Rendszam, existingWork.Rendszam);
            Assert.Equal(updatedWork.GyartasiEv, existingWork.GyartasiEv);
            Assert.Equal(updatedWork.Kategoria, existingWork.Kategoria);
            Assert.Equal(updatedWork.HibakLeirasa, existingWork.HibakLeirasa);
            Assert.Equal(updatedWork.HibaSulyossag, existingWork.HibaSulyossag);
            Assert.Equal(updatedWork.Allapot, existingWork.Allapot);
        }
    }
}
