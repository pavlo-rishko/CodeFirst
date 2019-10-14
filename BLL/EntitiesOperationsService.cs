using BLL.DTO;
using System;
using System.Collections.Generic;
using DAL.Models;
using DAL.UnitOfWork;

namespace BLL
{
    public class EntitiesOperationsService
    {
        public EntitiesOperationsService(IUnitOfWork unitOfWorkParam)
        {
            UnitOfWork = unitOfWorkParam ?? throw new ArgumentNullException(nameof(unitOfWorkParam));
        }
        private IUnitOfWork UnitOfWork { get; }


        public void AddStudent(StudentDto studentDto)
        {
            UnitOfWork.StudentRepository.Insert(MappService.CreateStudentData(studentDto));

        }
        public void AddGroup(GroupDto groupDto)
        {
            UnitOfWork.GroupRepository.Insert(MappService.CreateGroupData(groupDto));
        }
        public void AddDormitory(DormitoryDto dormitoryDto)
        {
            UnitOfWork.DormitoryRepository.Insert(MappService.CreateDormitoryData(dormitoryDto));
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
            UnitOfWork?.SaveChanges();
        }
    }
}
