using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models
{
    // Write your Student class here...
    public class Student{
         public int StudentId {get; set;}

         [Required]
         [MaxLength(100)]
          public string Name {get; set;}
           [Required]
           [EmailAddress]
           public string Email {get; set;}
           [Range (0,int.MaxValue, ErrorMessage="Year of joininig must be a positive number")]
            public int YearOfJoining {get; set;}
             public int CourseId {get; set;}

             public Course Course {get; set;}

    }
}
