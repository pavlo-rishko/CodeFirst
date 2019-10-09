using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly MYdbCodeFirstContext _studentDbEntities; 
        public StudentRepository(MYdbCodeFirstContext context) : base(context)
        {
            _studentDbEntities = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            IQueryable<Student> students = _studentDbEntities.Students.Include(s => s.Dormitory).Include(s => s.Group);
            return students.AsEnumerable();
        }
        public IEnumerable<Student> GetAllStudentsWithDormitory()
        {
            IQueryable<Student> students = _studentDbEntities.Students.Include(s => s.Dormitory).Include(s => s.Group);

            students = students.Where(s => s.DormitoryId.HasValue);
            return students.AsEnumerable();
        }

        public IEnumerable<Student> GetAllStudentsWithoutDormitory()
        {
            IQueryable<Student> students = _studentDbEntities.Students.Include(s => s.Group);

            students = students.Where(s => s.DormitoryId == null);
            return students.AsEnumerable();
        }
    }
}
