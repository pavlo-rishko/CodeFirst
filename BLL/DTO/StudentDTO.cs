using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{ 
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string GroupName { get; set; }
        public string DormitoryName { get; set; }
    }
}
