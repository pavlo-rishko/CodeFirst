
using System;

namespace BLL.DTO
{ 
    public class StudentDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int GroupName { get; set; }
        public int? DormitoryName { get; set; }
    }
}
