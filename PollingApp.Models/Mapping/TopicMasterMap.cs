using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Mapping
{
  public class TopicMasterMap : EntityTypeConfiguration<TopicMaster>
  {
    public TopicMasterMap()
    {
      ToTable("TopicMaster");
      Property(t => t.TopicId).HasColumnName("TopicId");
      Property(t => t.TopicCode).HasColumnName("TopicCode");
      Property(t => t.TopicName).HasColumnName("TopicName");
      Property(t => t.CreatedDate).HasColumnName("CreatedDate");
      Property(t => t.CreatedBy).HasColumnName("CreatedBy");
      Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
      Property(t => t.LastModifieddate).HasColumnName("LastModifieddate");
    }
  }
}
