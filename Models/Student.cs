using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Firstname { get; set; }
        [Required, MaxLength(30)]
        public string Lastname { get; set; }
        [Required]
        public int GroupId { get; set; }
        public int? DormitoryId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Dormitory Dormitory { get; set; }
    }
}
