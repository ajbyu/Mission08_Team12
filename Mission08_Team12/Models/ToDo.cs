using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team12.Models
{
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }
        [Required]
        public string Task { get; set; }
        public string DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool Completed { get; set; }
    }
}
