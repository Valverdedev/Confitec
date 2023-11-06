using Domain;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;

public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntidadeBase
{
    protected readonly IRepositoryBase<TEntity> _repository;

    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<TEntity> ObterPorIdAsync(int id)
    {
        return await _repository.ObterPorIdAsync(id);
    }

    public async Task<IEnumerable<TEntity>> ListarTodosAsync()
    {
        return await _repository.ListarTodosAsync();
    }

    public virtual async Task<TEntity> InserirAsync(TEntity entity)
    {
      return await _repository.InserirAsync(entity);
    }

    public async Task<bool> AtualizarAsync(TEntity entity)
    {
      return await _repository.AtualizarAsync(entity);
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        var entityParaDeletar = await ObterPorIdAsync(id);
        entityParaDeletar.Desativar();
        entityParaDeletar.AtualizarDataModificacao();
       return await AtualizarAsync(entityParaDeletar);
    }
   
    
}
