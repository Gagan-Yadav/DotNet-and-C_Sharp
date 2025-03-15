using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId {get; set;}
        public string TaskName {get; set;}
        public string Status {get; set;}
    }
}
