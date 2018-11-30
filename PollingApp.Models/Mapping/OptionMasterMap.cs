using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Mapping
{
    public class OptionMasterMap : EntityTypeConfiguration<OptionMaster>
    {
        public OptionMasterMap()
        {
            ToTable("OptionMaster");
            Property(t => t.OptionId).HasColumnName("OptionId");
            Property(t => t.OptionCode).HasColumnName("OptionCode");
            Property(t => t.OptionName).HasColumnName("OptionName");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
        }
    }

} 


