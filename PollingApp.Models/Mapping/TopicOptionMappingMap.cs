using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Mapping
{
   public  class TopicOptionMappingMap : EntityTypeConfiguration<TopicOptionMapping>
    {
        public TopicOptionMappingMap()
        {
            ToTable("TopicOptionMapping");
            Property(t => t.TopicOptionMappingId).HasColumnName("TopicOptionMappingId");
            Property(t => t.TopicId).HasColumnName("TopicId");
            Property(t => t.OptionId).HasColumnName("OptionId");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
            Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");

        }
    }
}
