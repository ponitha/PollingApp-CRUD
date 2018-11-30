using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models.Mapping
{
  public class AppRoleMap : EntityTypeConfiguration<AppRole>
  {
    public AppRoleMap()
    {
      ToTable("AppRole", "dbo");
      Property(t => t.AppRoleId).HasColumnName("AppRoleId");
      Property(t => t.RoleName).HasColumnName("RoleName");
      Property(t => t.CreatedBy).HasColumnName("CreatedBy");
      Property(t => t.CreatedDate).HasColumnName("CreatedDate");
      Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
      Property(t => t.LastModifiedDate).HasColumnName("LastModifiedDate");
    }
  }
}
