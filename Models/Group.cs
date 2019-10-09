using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string GroupName { get; set; }

        public List<Student> Students { get; set; }
    }
}
