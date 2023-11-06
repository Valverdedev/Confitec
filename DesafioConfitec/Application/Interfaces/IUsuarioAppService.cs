using Application.Dtos.UsuarioDtos;

namespace Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<ObjetoDeRetorno<UsuarioDto>> InserirAsync(InserirUsuarioDto dto);
        Task<ObjetoDeRetorno<IList<UsuarioDto>>> ListarTodosAsync();
        Task<ObjetoDeRetorno<UsuarioDto>> ExcluirAsync(int id);
        Task<ObjetoDeRetorno<UsuarioDto>> ObterPorIdAsync(int id);
        Task<ObjetoDeRetorno<UsuarioDto>> AtualizarAsync(int id, InserirUsuarioDto inserirUsuarioDto);
    }
}
