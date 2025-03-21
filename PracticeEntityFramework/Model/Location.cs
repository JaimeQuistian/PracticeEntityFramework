using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PracticeEntityFramework.Model
{
    [Table("Location", Schema = "Production")]
    public class Location
    {
        [Key]
        public short LocationId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal CostRate { get; set; }

        [Required]
        public decimal Availability { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}