using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yuli_Garnaga_test.Models
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Description_Q { get; set; } = string.Empty;
        [Required]
        public int TypeId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;




    }
}
