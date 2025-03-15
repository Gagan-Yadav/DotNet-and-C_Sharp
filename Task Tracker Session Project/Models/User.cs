using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class User
    {

        [Key]
        public int Uid {get; set;}

        public string UserName {get; set;}

        public string Password {get; set;}
        
    }
}
