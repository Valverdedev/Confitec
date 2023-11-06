using Domain;
using Domain.RepositoryInterfaces;
using Infra_db.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_db.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        protected readonly ContextSql _dbContext;

        public RepositoryBase(ContextSql dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AtualizarAsync(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          
        }

       
        public async Task<TEntity> InserirAsync(TEntity entity)
        {
          await  _dbContext.Set<TEntity>().AddAsync(entity);
          await _dbContext.SaveChangesAsync();
          return entity;
        }

        public async Task<IEnumerable<TEntity>> ListarTodosAsync()
        {
            var entity = await _dbContext.Set<TEntity>().Where(predicate: entity => entity.Ativo).AsNoTracking().ToListAsync();
            if (entity == null)
            {

                throw new RegrasDeNegocioException($"Entidades {typeof(TEntity).Name} não encontradas.");
            }

            return entity;
        }

        public async Task<TEntity> ObterPorIdAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate: entity => entity.Id == id && entity.Ativo);
            if (entity == null)
            {

                throw new RegrasDeNegocioException($"Entidade {typeof(TEntity).Name} com Id {id} não encontrada.");
            }

            return entity;
        }

        
    }
}
