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
        var usuario = new Usuario { PrimerNombre = "John", PrimerApellido = "Doe",SegundoApellido = "perez", FechaCreacion = DateTime.Now,Sueldo=123 };

        // Act
        bool result = service.crearUsuario(usuario);

        // Assert
        Assert.True(result);
        mockSet.Verify(m => m.Add(It.IsAny<Usuario>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [Fact]
    public void EditarUsuario_ReturnsTrue_WhenUserExists()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Usuario>>();
        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(m => m.Personas).Returns(mockSet.Object);

        var service = new MetodoUsuario(mockContext.Object);
        var usuario = new Usuario { PrimerNombre = "John", PrimerApellido = "Doe", SegundoApellido = "perez", FechaCreacion = DateTime.Now, Sueldo = 123 };

        // Act
        var result = service.editarUsuario(usuario);

        // Assert
        Assert.True(result);
        mockSet.Verify(m => m.Update(It.IsAny<Usuario>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [Fact]
    public void EliminarUsuario_ReturnsTrue_WhenUserExists()
    {
        // Arrange
        var data = new List<Usuario>
        {
           new Usuario { Id = 1, PrimerNombre = "John", PrimerApellido = "Doe",SegundoApellido = "perez", FechaCreacion = DateTime.Now,Sueldo=123 },
           new Usuario { Id = 2, PrimerNombre = "maicol", PrimerApellido = "esteban",SegundoApellido = "perez", FechaCreacion = DateTime.Now,Sueldo=123 }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Usuario>>();
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(m => m.Personas).Returns(mockSet.Object);

        var service = new MetodoUsuario(mockContext.Object);

        // Act
        var result = service.eliminarUsuario(1);

        // Assert
        Assert.True(result);
        mockSet.Verify(m => m.Remove(It.IsAny<Usuario>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [Fact]
    public void ListarUsuario_ReturnsAllUsers_IfAnyExist()
    {
        // Arrange
        var data = new List<Usuario>
        {
            new Usuario { Id = 1, PrimerNombre = "John" },
        new Usuario { Id = 2, PrimerNombre = "Jane" }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Usuario>>();
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(m => m.Personas).Returns(mockSet.Object);

        var service = new MetodoUsuario(mockContext.Object);

        // Act
        var result = service.listarUsuario();

        // Assert
        Assert.Equal(2, result.Count); // Expecting 2 users as per the arranged data
        Assert.Contains(result, u => u.PrimerNombre == "John");
        Assert.Contains(result, u => u.PrimerNombre == "Jane");
    }

    [Fact]
    public void ListarUsuarioXId_ReturnsUser_IfUserExists()
    {
        // Arrange
        var data = new List<Usuario>
        {
           new Usuario { Id = 1, PrimerNombre = "John", PrimerApellido = "Doe",SegundoApellido = "perez", FechaCreacion = DateTime.Now,Sueldo=123 },
           new Usuario { Id = 2, PrimerNombre = "maicol", PrimerApellido = "esteban",SegundoApellido = "perez", FechaCreacion = DateTime.Now,Sueldo=123 }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Usuario>>();
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(m => m.Personas).Returns(mockSet.Object);

        var service = new MetodoUsuario(mockContext.Object);

        // Act
        var result = service.listarUsuarioXId(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John", result.PrimerNombre);
    }

    [Fact]
    public void ListarUsuarioXId_ReturnsNewUser_IfUserDoesNotExist()
    {
        // Arrange
        var data = new List<Usuario>().AsQueryable(); 

        var mockSet = new Mock<DbSet<Usuario>>();
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns((Usuario)null); 

        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(m => m.Personas).Returns(mockSet.Object);

        var service = new MetodoUsuario(mockContext.Object);
        int id = 50; // ID that does not exist

        // Act
        var result = service.listarUsuarioXId(id); // Assuming ID is 0 for new User objects
        Assert.NotNull(result);
        Assert.Equal(0, result.Id);
    }
}