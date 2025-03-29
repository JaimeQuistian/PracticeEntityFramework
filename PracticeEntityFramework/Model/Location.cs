using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PracticeEntityFramework.Model
{
    /*
      Definir la entidad Location, que se vincula con la tabla "Location" dentro del esquema 
      "Production" de la base de datos AdventureWorks2022.
    */
    [Table("Location", Schema = "Production")] //Esta clase representa la tabla Location del esquema Production
    public class Location
    {
        [Key]
        public short LocationId { get; set; } // Llave primaria

        [Required] // Campos requeridos (obligatorios)
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