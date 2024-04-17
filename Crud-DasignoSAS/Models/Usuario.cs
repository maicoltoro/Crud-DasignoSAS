using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_DasignoSAS.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sueldo {  get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.PrimerNombre).NotNull().Matches(@"^[a-zA-Z\s]*$").WithMessage("El primer nombre solo debe contener letras.").MaximumLength(50);
            RuleFor(x => x.SegundoNombre).MaximumLength(50).Matches(@"^[a-zA-Z\s]*$").WithMessage("El segundo nombre solo debe contener letras.");

            RuleFor(x => x.PrimerApellido).NotNull().Matches(@"^[a-zA-Z\s]*$").WithMessage("El primer apellido solo debe contener letras.").MaximumLength(50);
            RuleFor(x => x.SegundoApellido).Matches(@"^[a-zA-Z\s]*$").WithMessage("El segundo apellido solo debe contener letras.").MaximumLength(50);

            RuleFor(x => x.Sueldo).NotNull().GreaterThan(0).WithMessage("El sueldo debe ser mayor a 0.");

            RuleFor(x => x.FechaNacimiento).NotNull();            
        }
    }
}
