using Crud_DasignoSAS.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_DasignoSAS.Clases
{
    public class MetodoUsuario
    {

        private readonly ApplicationDbContext _context;

        public MetodoUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool crearUsuario(Usuario usuario)
        {
            try
            {
                usuario.FechaCreacion = DateTime.Now;
                _context.Personas.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool editarUsuario(Usuario usuario)
        {
            try
            {
                usuario.FechaModificacion = DateTime.Now;
                _context.Personas.Update(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool eliminarUsuario(int id)
        {
            try
            {
                var usuario = _context.Personas.Where(p => p.Id == id).FirstOrDefault();
                if (usuario != null)
                {
                    _context.Personas.Remove(usuario);
                    _context.SaveChanges();
                    return true;
                }
                return false;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> listarUsuario()
        {
            try
            {
                var datos = _context.Personas.ToList();
                if (datos.Count > 0)
                    return datos;
                else
                    return new List<Usuario>();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario listarUsuarioXId(int id)
        {
            try
            {
                var datos = _context.Personas.Where(e => e.Id == id).FirstOrDefault();
                if (datos != null)
                    return datos;
                else
                    return new Usuario();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> listarUsuarioXNombre(string nombre, string apellido)
        {
            try
            {
                var datos = _context.Personas
                    .Where(e => e.PrimerNombre == nombre || e.PrimerApellido == apellido)
                    .ToList();
                if (datos.Count > 0)
                    return datos;
                else
                    return new List<Usuario>();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
