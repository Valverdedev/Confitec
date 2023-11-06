using Domain.Entidades;
using Domain.RepositoryInterfaces;

namespace Domain.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<bool> UsuarioExistePorEmail(string email);
    }
}
