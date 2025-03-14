using System.ComponentModel.DataAnnotations;

namespace PracticeEntityFramework.Model
{
    public class Location
    {
        [Key]
        public required short LocationId { get; set; }
        public required string Name { get; set; }
        public required decimal CostRate { get; set; }
        public required decimal Availability { get; set; }
        public required decimal ModifiedDate { get; set; }
        public required DateTime ModifiedTime { get; set; }

    }
}
