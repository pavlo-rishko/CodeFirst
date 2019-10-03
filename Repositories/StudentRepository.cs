using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly MYdbCodeFirstContext studentDbEntities; 
        public StudentRepository(MYdbCodeFirstContext context) : base(context)
        {
            studentDbEntities = context;
        }


        public IEnumerable<Student> GetAllStudentsWithDormitory()
        {
            IQueryable<Student> students = studentDbEntities.Students.Include(s => s.Dormitory).Include(s => s.Group);

            students = students.Where(s => s.DormitoryId.HasValue);
            return students.AsEnumerable();
        }

        public IEnumerable<Student> GetAllStudentsWithoutDormitory()
        {
            IQueryable<Student> students = studentDbEntities.Students.Include(s => s.Group);

            students = students.Where(s => s.DormitoryId == null);
            return students.AsEnumerable();
        }
    }
}
