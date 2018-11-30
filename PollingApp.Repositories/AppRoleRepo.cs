using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Repositories
{
  public class AppRoleRepo : Repository<AppRole>, IAppRoleRepo
  {
    public AppRoleRepo(PollingAppContext context) : base(context)
    {
    }
  }
}
