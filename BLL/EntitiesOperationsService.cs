using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class EntitiesOperationsService
    {
        public EntitiesOperationsService(IUnitOfWork unitOfWorkParam)
        {
            UnitOfWork = unitOfWorkParam ?? throw new ArgumentNullException(nameof(unitOfWorkParam));
        }
        private IUnitOfWork UnitOfWork { get; }


        public void AddStudent(StudentDTO studentDTO)
        {
            UnitOfWork.StudentRepository.Insert(MappService.CreateStudentData(studentDTO));

        }
        public void AddGroup(GroupDTO groupDTO)
        {
            UnitOfWork.GroupRepository.Insert(MappService.CreateGroupData(groupDTO));
        }
        public void AddDormitory(DormitoryDTO dormitoryDTO)
        {
            UnitOfWork.DormitoryRepository.Insert(MappService.CreateDormitoryData(dormitoryDTO));
        }        
        public IEnumerable<Student> GetAllStudents()
        {
            return UnitOfWork.StudentRepository.GetAllStudents();
        }
        public IEnumerable<Student> GetAllStudentsWithoutDormitory()
        {
            return UnitOfWork.StudentRepository.GetAllStudentsWithoutDormitory();
        }
        public IEnumerable<Student> GetAllStudentsWithDormitory()
        {
            return UnitOfWork.StudentRepository.GetAllStudentsWithDormitory();
        }


        public IEnumerable<Group> GetAllGroups()
        {
            return UnitOfWork.GroupRepository.GetAll();
        }
        public IEnumerable<Dormitory> GetAllDormitories()
        {
            return UnitOfWork.DormitoryRepository.GetAll();
        }

        public int CountNumberGroups()
        {
            return UnitOfWork.GroupRepository.Count();
        }
        public int CountNumberDormitories()
        {
            return UnitOfWork.StudentRepository.Count();
        }

        public void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}
