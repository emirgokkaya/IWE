using System.Linq.Expressions;
using IWE.Core.Abstract;
using IWE.DAL.Contexts;
using IWE.Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace IWE.Core.Concrete;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IBase, new()
{
    private readonly IWEContext _context;

    public BaseRepository(IWEContext context)
    {
        _context = context;
    }

    public bool Create(T entity)
    {
        try
        {
            Set().Add(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(T entity)
    {
        try
        {
            Set().Update(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(T entity)
    {
        try
        {
            Set().Remove(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public T Find(int id)
    {
        return Set().Find(id);
    }



    public List<T> List()
    {
        return Set().ToList();
    }

    public DbSet<T> Set()
    {
        return _context.Set<T>();
    }

    public IQueryable<T> Get()
    {
        return Set().ToList().AsQueryable();
    }
}