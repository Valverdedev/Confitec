using Domain.Entidades;
using Domain.Repository;
using Infra_db.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_db.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextSql dbContext) : base(dbContext)
        {
        
        }

        public async Task<bool> UsuarioExistePorEmail(string email)
        {
            return  await _dbContext.Set<Usuario>().AnyAsync(entity => entity.Email == email);           
        }
    }
}
