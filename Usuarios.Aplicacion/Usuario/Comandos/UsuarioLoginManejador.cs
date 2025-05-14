

using AutoMapper;
using MediatR;
using System.Net;
using Usuarios.Aplicacion.Comun;
using Usuarios.Aplicacion.Usuario.Dto;
using Usuarios.Aplicacion.Usuario.Herramientas;
using Usuarios.Dominio.Servicios.Usuarios;

namespace Usuarios.Aplicacion.Usuario.Comandos
{
    public class UsuarioLoginManejador : IRequestHandler<UsuarioLoginComando, LoginOut>
    {
        private readonly IMapper _mapper;
        private readonly ConsultarUsuario _consultarUsuario;

        public UsuarioLoginManejador(IMapper mapper, ConsultarUsuario consultarUsuario) 
        {
            _mapper = mapper;
            _consultarUsuario = consultarUsuario;

        }
        public async Task<LoginOut> Handle(UsuarioLoginComando request, CancellationToken cancellationToken)
        {
            LoginOut output = new();

            try
            {
                var usuario = await _consultarUsuario.Ejecutar(request.Username);

                if (usuario == null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "Usuario no encontrado";
                    output.Status = HttpStatusCode.NotFound;
                }
                else 
                { 
                    var claveCifrada = Utilidades.Cifrar(request.Contrasena);

                    if (claveCifrada == usuario.Contrasena)
                    {
                        output.Mensaje = "Operación exitosa";
                        output.Resultado = Resultado.Exitoso;
                        output.Status = HttpStatusCode.OK;
                    }
                    else 
                    {
                        output.Mensaje = "Usuario y/o clave incorrecta";
                        output.Resultado = Resultado.Error;
                        output.Status = HttpStatusCode.Conflict;
                    }
                }
                    
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = string.Concat("Message: ", ex.Message, ex.InnerException is null ? "" : "-InnerException-" + ex.InnerException.Message);
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }
}
