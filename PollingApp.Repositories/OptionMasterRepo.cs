using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Repositories
{
  public class OptionMasterRepo : Repository<OptionMaster>, IOptionMasterRepo
  {
    public OptionMasterRepo(PollingAppContext context) : base(context)
    {
    }
  }
}
