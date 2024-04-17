using Crud_DasignoSAS.Clases;
using Crud_DasignoSAS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud_DasignoSAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly MetodoUsuario _solicitudService;

        public UsuariosController(MetodoUsuario solicitudService)
        {
            _solicitudService = solicitudService;
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> CrearUsuario(Usuario usuario)
        {
            var Validador = new Validador();
            var resultValidador = await Validador.validadorDatos(usuario);
            if (resultValidador.Equals(""))
            {
                var DbResultado = _solicitudService.crearUsuario(usuario);
                if (DbResultado)
                    return Ok(DbResultado);
                else
                    return BadRequest();
            }
            else
                return BadRequest(resultValidador);
        }

        //[Authorize]
        [HttpPut]
        public async Task<IActionResult> EditarUsuario(Usuario usuario)
        {
            var Validador = new Validador();
            var resultValidador = await Validador.validadorDatos(usuario);
            if (resultValidador.Equals(""))
            {
                var DbResultado = _solicitudService.editarUsuario(usuario);
                if (DbResultado)
                    return Ok(DbResultado);
                else
                    return BadRequest();
            }
            else
                return BadRequest(resultValidador);
        }

        //[Authorize]
        [HttpDelete]
        public IActionResult EliminarUsuario(int id)
        {
            var DbResultado = _solicitudService.eliminarUsuario(id);
            if (DbResultado)
                return Ok(DbResultado);
            else
                return BadRequest("User no encontrado");
        }

        //[Authorize]
        [HttpGet]
        public  IActionResult ListarUsuario()
        {
            var DbResultado = _solicitudService.listarUsuario();
            return Ok(DbResultado);
        }

        //[Authorize]
        [HttpGet("{id}")]
        public IActionResult ListarUsuarioXId(int id)
        {
            var DbResultado = _solicitudService.listarUsuarioXId(id);
            return Ok(DbResultado);
        }

        //[Authorize]
        [HttpGet("{nombre},{apellido}")]
        public IActionResult ListarUsuarioXNombres(string nombre, string apellido)
        {
            var DbResultado = _solicitudService.listarUsuarioXNombre(nombre,apellido);
            return Ok(DbResultado);
        }
    }
}
