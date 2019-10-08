using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DTO;
using DAL;

namespace BLL.Services
{
    class StudentService : IStudentService
    {
        IUnitOfWork unitOfWork;
        StudentService (IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public IEnumerable<Student> GetAllStudents(StudentDTO student)
        {
            return unitOfWork.StudentRepository.GetAll();
        }

    }
}
