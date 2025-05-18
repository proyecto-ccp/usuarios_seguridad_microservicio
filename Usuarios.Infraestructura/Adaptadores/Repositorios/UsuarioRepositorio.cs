using Usuarios.Dominio.Entidades;
using Usuarios.Dominio.Puertos.Repositorios;
using Usuarios.Infraestructura.Adaptadores.RepositorioGenerico;
using System.Diagnostics.CodeAnalysis;

namespace Usuarios.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IRepositorioBase<Usuario> _repositorioUsuario;

        public UsuarioRepositorio(IRepositorioBase<Usuario> repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<Usuario> Actualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Crear(Usuario usuario)
        {
            return await _repositorioUsuario.Guardar(usuario);
        }

        public Task<Usuario> Eliminar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ObtenerPorId(Guid id)
        {
            return await _repositorioUsuario.BuscarPorLlave(id);
        }

        public async Task<Usuario> ObtenerPorUsername(string username)
        {
            return await _repositorioUsuario.BuscarPorCampos(x => x.Username == username);
        }

        public Task<List<Usuario>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
