using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class ProjectTest
    {
         public int ProjectTestID {get; set;}
          [Required]
          public int ProjectID {get; set;}
           [Required]
           public int TesterName {get; set;}
            [Required]
            [Range(1,10,ErrorMessage="The rating must be betweeen 1 and 10!")]
            public int Rating {get; set;}
             public Project? Projects {get; set;}
    }
}
