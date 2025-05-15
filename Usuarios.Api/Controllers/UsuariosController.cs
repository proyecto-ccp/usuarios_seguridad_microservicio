
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Aplicacion.Comun;
using Usuarios.Aplicacion.Usuario.Comandos;
using Usuarios.Aplicacion.Usuario.Dto;

namespace Usuarios.Api.Controllers
{
    /// <summary>
    /// Controlador de atributos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// constructor
        /// </summary>
        public UsuariosController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crea un usuario nuevo en el sistema
        /// </summary>
        /// <response code="201"> 
        /// UsuarioOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("Crear")]
        [ProducesResponseType(typeof(UsuarioOut), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Crear([FromBody] UsuarioCrearComando usuario)
        {
            var output = await _mediator.Send(usuario);

            if (output.Resultado != Resultado.Error)
            {
                return Created(string.Empty, output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Iniciar sesión en el sistema
        /// </summary>
        /// <response code="200"> 
        /// LoginOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(LoginOut), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginComando login)
        {
            var output = await _mediator.Send(login);

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

    }
}
