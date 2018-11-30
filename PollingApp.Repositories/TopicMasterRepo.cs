using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Repositories
{
  public class TopicMasterRepo : Repository<TopicMaster>, ITopicMasterRepo
  {
    public TopicMasterRepo(PollingAppContext context) : base(context)
    {
    }
  }
}
