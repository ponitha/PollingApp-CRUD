using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PollingApp.Repositories
{
  public interface IRepository<TEntity> : IDisposable where TEntity : class
  {
    DbContext Context { get; }
    void Add(ref TEntity entity);
    void Delete(object id);
    List<TEntity> GetAll();
    TEntity Get(object id);
    void Update(TEntity entity);
    IQueryable<TEntity> SelectQuery(Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort = null,
      params Expression<Func<TEntity, object>>[] include);
  }
}
