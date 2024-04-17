using Crud_DasignoSAS.Clases;
using Crud_DasignoSAS.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Crud_DasignoSAS.Pruebas;

public class UnitTest1
{
    [Fact]
    public void CrearUsuario_AddsUserAndSavesChanges()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Usuario>>();
        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(m => m.Personas).Returns(mockSet.Object);

        var service = new MetodoUsuario(mockContext.Object);
        var usuario = new Usuario { PrimerNombre = "John", PrimerApellido = "Doe" };

        // Act
        bool result = service.crearUsuario(usuario);

        // Assert
        Assert.True(result);
        mockSet.Verify(m => m.Add(It.IsAny<Usuario>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
}