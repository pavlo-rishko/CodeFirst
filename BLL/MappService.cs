using BLL.DTO;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BLL
{
    public static class MappService
    {
        public static IServiceCollection ConfigureBllDependencies(this IServiceCollection serviceCollection,
         Action<DbContextOptionsBuilder> optionsAction)
        {
            serviceCollection.ConfigureDalDependencies(optionsAction);
            serviceCollection.AddTransient<EntitiesOperationsService>();
            return serviceCollection;
        }
        public static StudentDTO CreateStudentDTO(string firstname, string lastname, string groupName, string dormitoryName)
        {
            StudentDTO data = new StudentDTO
            {

                Firstname = firstname,
                Lastname = lastname,
                GroupName = groupName,
                DormitoryName = dormitoryName

            };
            return data;
        }
        public static GroupDTO CreateGroupDTO(string groupName, int id = default)
        {
            GroupDTO data = new GroupDTO
            {
                Id = id,
                GroupName = groupName
            };
            return data;
        }

        public static DormitoryDTO CreateDormitoryDTO( string dormitoryName, int id = default)
        {
            DormitoryDTO data = new DormitoryDTO
            {
                Id = id,
                NameDormitory = dormitoryName
            };
            return data;
        }

        public static Student CreateStudentData(StudentDTO student)
        {
            Student data = new Student
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                GroupId = Convert.ToInt32(student.GroupName),
                DormitoryId = Convert.ToInt32(student.DormitoryName)

            };
            return data;
        }
        public static Dormitory CreateDormitoryData(DormitoryDTO dormitory)
        {
            Dormitory data = new Dormitory
            {
                NameDormitory = dormitory.NameDormitory
            };
            return data;
        }

        public static Group  CreateGroupData(GroupDTO groupDTO)
        {
            Group data = new Group
            {
                GroupName = groupDTO.GroupName
            };
            return data;
        }

    }
}
