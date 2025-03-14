using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class Project
    {
        [key]
        public int ProjectID {get; set;}
        [Required]
         public string Title {get; set;}
           [Required]
          public string Manager {get; set;}

           public ICollection<ProjectTest> ProjectTests {get; set;}
    }
}
