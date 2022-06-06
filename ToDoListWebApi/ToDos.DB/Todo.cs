using System;
using System.ComponentModel.DataAnnotations;

namespace ToDos.DB
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsDone { get; set; }
    }
}
