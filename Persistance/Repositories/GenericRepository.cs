namespace Persistance.Repositories
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext _context) :
        IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {

        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetAsync(TKey key) => await _context.Set<TEntity>().FindAsync(key);
    }
}
