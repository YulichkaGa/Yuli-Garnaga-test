using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yuli_Garnaga_test.Models
{

    public class Answers
    {

        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [ForeignKey("Id_Q")]
        public int QId { get; set; }
        [Required]
        [ForeignKey("Id_Type")]
        public int TypeId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
