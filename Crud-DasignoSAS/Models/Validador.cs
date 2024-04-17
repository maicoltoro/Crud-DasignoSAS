namespace Crud_DasignoSAS.Models
{
    public class Validador
    {
        public async Task<string> validadorDatos ( Usuario usuario) {
            var resultValidador = new UsuarioValidator().Validate(usuario);
            string error = "";
            if (!resultValidador.IsValid)
            {
                foreach (var failure in resultValidador.Errors)
                {
                    error += $"Error: {failure.ErrorMessage}";
                }
            }
            return error;
        }
    }
}
