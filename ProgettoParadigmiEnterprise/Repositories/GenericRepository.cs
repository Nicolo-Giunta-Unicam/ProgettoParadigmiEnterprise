using ProgettoParadigmiEnterprise.Context;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected DatabaseRistorante context { get; set; }

        public GenericRepository(DatabaseRistorante _context)
        {
            context = _context;
        }

        public virtual T Get(object id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
