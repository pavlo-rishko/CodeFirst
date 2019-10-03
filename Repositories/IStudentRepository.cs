using System.Collections.Generic;

namespace DAL
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetAllStudentsWithDormitory();
        IEnumerable<Student> GetAllStudentsWithoutDormitory();
    }
}
