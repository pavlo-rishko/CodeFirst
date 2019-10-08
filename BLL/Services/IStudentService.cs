using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    interface IStudentService : IDisposable
    {
        IEnumerable<Student> GetAllStudents(StudentDTO student);
        
    }
}
