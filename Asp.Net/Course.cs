using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace dotnetapp.Models
{
    public class Course{
        public int CourseId {get; set;}
        
        [Required]
        [MaxLength(100)]
         public string Title {get; set;}
         [MaxLength(500)]
          public string Description {get; set;}

         public  ICollection<Student> Students {get; set;}
    }
}
