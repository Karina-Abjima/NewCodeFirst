using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_CFA.Dto
{
    public class StudentDto
    {
       
        public Guid StudentId { get; set; }
        public string FName { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
      
        public int Roll { get; set; }

      
        public long Contact { get; set; }
       
        public string address { get; set; }
    }
}
