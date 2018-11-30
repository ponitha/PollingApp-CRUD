using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models
{
  public class TopicMaster
  {
    [Key]
    public int TopicId { get; set; }
    [Required]
    [MaxLength(10)]
    [Display(Name = "Topic Code")]
    public string TopicCode { get; set; }
    [Required]
    [MaxLength(50)]
    [Display(Name = "Topic Name")]
    public string TopicName { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifieddate { get; set; }

  }
}
