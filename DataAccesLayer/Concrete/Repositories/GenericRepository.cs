using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System.Data.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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
        _object.Remove(p);
    }

    public void Insert(T p)
    {
        _object.Add(p);
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
        _context.SaveChanges();
    }

    T IRepository<T>.Get(Expression<Func<T, bool>> filter)
    {
        return _object.SingleOrDefault(filter);
    }
}
