namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> ObterPorIdAsync(int id);
        Task<IEnumerable<TEntity>> ListarTodosAsync();
        Task<TEntity> InserirAsync(TEntity entity);
        Task<bool> AtualizarAsync(TEntity entity);


    }
}
