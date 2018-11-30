using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace PollingApp.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private readonly DbContext _context;
    public DbContext Context
    {
      get { return _context; }
    }

    public Repository(DbContext context)
    {
      _context = context;
      SetCommandTimeout(_context.Database.Connection.ConnectionTimeout);
    }

    public DbSet<TEntity> DbSet
    {
      get { return _context.Set<TEntity>(); }
    }

    public void Add(ref TEntity entity)
    {
      try
      {
        DbSet.Add(entity);
        _context.SaveChanges();
      }
      catch (DbUpdateException dbEx)
      {
        var entry = _context.Entry(entity);
        if (entry.State == EntityState.Added)
        {
          DbSet.Remove(entity);
        }
        CustomDbExceptionHandler.ThrowHandledError(dbEx);
        throw;
      }
      catch (DbEntityValidationException ex)
      {
        // Retrieve the error messages as a list of strings.
        var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);

        // Join the list to a single string.
        var fullErrorMessage = string.Join("; ", errorMessages);

        // Combine the original exception message with the new one.
        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

        // Throw a new DbEntityValidationException with the improved exception message.
        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
      }
    }

    public void Delete(object id)
    {
      try
      {
        var entity = DbSet.Find(id);
        DbSet.Remove(entity);
        _context.SaveChanges();
      }
      catch (DbUpdateException dbEx)
      {
        CustomDbExceptionHandler.ThrowHandledError(dbEx);
        throw;
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    public TEntity Get(object id)
    {
      return DbSet.Find(id);
    }

    public List<TEntity> GetAll()
    {
      return DbSet.AsNoTracking().ToList();
    }
    public virtual IQueryable<TEntity> SelectQuery(Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort = null,
      params Expression<Func<TEntity, object>>[] include)
    {
      IQueryable<TEntity> dbQuery = DbSet;

      if (filter != null)
      {
        dbQuery = dbQuery.Where(filter);
      }

      if (include != null)
      {
        dbQuery = include.Aggregate(dbQuery, (a, b) => a.Include(b));
      }

      if (sort != null)
      {
        dbQuery = sort(dbQuery);
      }

      return dbQuery;
    }

    public void Update(TEntity entity)
    {
      try
      {
        DbSet.AsNoTracking();
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
      }
      catch (DbUpdateException dbEx)
      {
        CustomDbExceptionHandler.ThrowHandledError(dbEx);
        throw;
      }
    }

    private void SetCommandTimeout(int timeout)
    {
      timeout = timeout < 299 ? 300 : timeout;
      var objContext = (_context as IObjectContextAdapter).ObjectContext;
      objContext.CommandTimeout = timeout;
    }
    private void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (Convert.ToString(ConfigurationManager.AppSettings["DoNotDispose"]) == "true")
          return;
        if (_context != null)
        {
          _context.Dispose();
        }
      }
    }
  }
}
