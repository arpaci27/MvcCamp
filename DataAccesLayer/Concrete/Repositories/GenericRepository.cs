using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System.Data.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly Context _context;
    private readonly Microsoft.EntityFrameworkCore.DbSet<T> _object;

    public GenericRepository(Context context)
    {
        _context = context;
        _object = _context.Set<T>();
    }

    public void Delete(T p)
    {
        var deletedEntity = _context.Entry(p);
        deletedEntity.State = EntityState.Deleted;
        //_object.Remove(p);
        _context.SaveChanges();
    }

    public void Insert(T p)
    {
        var addedEntity = _context.Entry(p);
        addedEntity.State = EntityState.Added;
        //_object.Add(p);
        _context.SaveChanges();
    }

    public List<T> List()
    {
        return _object.ToList();
    }

    public List<T> List(Expression<Func<T, bool>> filter)
    {
        return _object.Where(filter).ToList();
    }

    public void Update(T p)
    {
        var updatedEntity = _context.Entry(p);
        updatedEntity.State = EntityState.Modified;
        _context.SaveChanges();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        return _object.SingleOrDefault(filter);


    }
}

