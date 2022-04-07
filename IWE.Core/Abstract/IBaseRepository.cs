using System.Linq.Expressions;
using IWE.Entity.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWE.Core.Abstract;

public interface IBaseRepository<T> where T : class, IBase, new()
{
    bool Create(T entity);
    bool Update(T entity);
    bool Delete(T entity);
    T Find(int id);
    List<T> List();
    DbSet<T> Set();
    IQueryable<T> Get();
}