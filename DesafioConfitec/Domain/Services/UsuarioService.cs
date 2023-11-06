using Domain.Entidades;
using Domain.Repository;
using Domain.ServiceInterfaces;

namespace Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
          _usuarioRepository = repository;
        }

        public override async Task<Usuario> InserirAsync(Usuario usuario)
        {
            if (await _usuarioRepository.UsuarioExistePorEmail(usuario.Email))
            {
                throw new RegrasDeNegocioException("Já existe um usuário com esse email");
            }

            return await base.InserirAsync(usuario);
        }
    }
    
}
