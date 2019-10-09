using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetAllStudentsWithDormitory();
        IEnumerable<Student> GetAllStudentsWithoutDormitory();
    }
}
