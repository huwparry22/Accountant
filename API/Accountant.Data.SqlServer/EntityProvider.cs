using Accountant.Data.SqlServer.Context;

namespace Accountant.Data.SqlServer
{
    public class EntityProvider<T> : IEntityProvider<T> where T : class
    {
        internal readonly AccountantContext _accountantContext;

        public EntityProvider(AccountantContext accountantContext)
        {
            _accountantContext = accountantContext;
        }

        public async Task<T> SaveAsync(T entity)
        {
            using (var transaction = await _accountantContext.Database.BeginTransactionAsync().ConfigureAwait(false))
            {
                try
                {
                    var entityEntry = _accountantContext.Entry(entity);

                    switch(entityEntry.State)
                    {
                        case Microsoft.EntityFrameworkCore.EntityState.Added:
                        case Microsoft.EntityFrameworkCore.EntityState.Detached:
                            _accountantContext.Set<T>().Add(entity);
                            break;
                        case Microsoft.EntityFrameworkCore.EntityState.Modified:
                            _accountantContext.Set<T>().Update(entity);
                            break;
                        case Microsoft.EntityFrameworkCore.EntityState.Deleted:
                            _accountantContext.Set<T>().Remove(entity);
                            break;
                    }

                    await _accountantContext.SaveChangesAsync().ConfigureAwait(false);

                    await transaction.CommitAsync().ConfigureAwait(false);

                    return entity;
                }
                catch
                {
                    await transaction.RollbackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
    }
}
