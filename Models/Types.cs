using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Yuli_Garnaga_test.Models
{
    public class Types
    {
      
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Key]
        public string TypeId { get; set; } = string.Empty;
    }
}
