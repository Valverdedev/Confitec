namespace Domain.ServiceInterfaces
{
    public interface IServiceBase<TEntity> where TEntity : EntidadeBase
    {
        Task<TEntity> ObterPorIdAsync(int id);
        Task<IEnumerable<TEntity>> ListarTodosAsync();
        Task<TEntity> InserirAsync(TEntity entity);        
        Task<bool> AtualizarAsync(TEntity entity);
        Task<bool> ExcluirAsync(int id);

    }

}
