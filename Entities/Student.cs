using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Assignment_CFA.Entities
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentId { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
       
        public string Lname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Roll { get; set; }
        [Required]
        public long Contact { get; set; }
        [Required]
        public string address { get; set; }
      

    } 
}
