using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace PollingApp.Repositories
{
  public class CustomDbExceptionHandler
  {
    public static void ThrowHandledError(DbUpdateException dbEx)
    {
      SqlException sqlEx = dbEx.InnerException.InnerException as SqlException;

      if (sqlEx != null && sqlEx.Number == 2627)
      {
        throw new UniqueKeyException();
      }

      if (sqlEx != null && sqlEx.Number == 547)
      {
        throw new ForiegnKeyException();
      }
      if (sqlEx != null && sqlEx.Number == 2601)
      {
        throw new UniqueKeyException();
      }
    }
  }
}
