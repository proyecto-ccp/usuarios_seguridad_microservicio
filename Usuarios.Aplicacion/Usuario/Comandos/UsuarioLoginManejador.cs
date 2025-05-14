

using AutoMapper;
using MediatR;
using Usuarios.Aplicacion.Usuario.Dto;

namespace Usuarios.Aplicacion.Usuario.Comandos
{
    public class UsuarioLoginManejador : IRequestHandler<UsuarioLoginComando, LoginOut>
    {
        private readonly IMapper _mapper;

        public UsuarioLoginManejador(IMapper mapper) 
        {
            _mapper = mapper;

        }
        public Task<LoginOut> Handle(UsuarioLoginComando request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
