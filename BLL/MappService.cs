using BLL.DTO;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using DAL.Models;

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
        public static StudentDto CreateStudentDto(string firstname, string lastname, string groupName, string dormitoryName)
        {
            StudentDto data = new StudentDto
            {

                Firstname = firstname,
                Lastname = lastname,
                GroupName = groupName,
                DormitoryName = dormitoryName

            };
            return data;
        }
        public static GroupDto CreateGroupDto(string groupName, int id = default)
        {
            GroupDto data = new GroupDto
            {
                Id = id,
                GroupName = groupName
            };
            return data;
        }

        public static DormitoryDto CreateDormitoryDto( string dormitoryName, int id = default)
        {
            DormitoryDto data = new DormitoryDto
            {
                Id = id,
                NameDormitory = dormitoryName
            };
            return data;
        }

        public static Student CreateStudentData(StudentDto student)
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
        public static Dormitory CreateDormitoryData(DormitoryDto dormitory)
        {
            Dormitory data = new Dormitory
            {
                NameDormitory = dormitory.NameDormitory
            };
            return data;
        }

        public static Group  CreateGroupData(GroupDto groupDto)
        {
            Group data = new Group
            {
                GroupName = groupDto.GroupName
            };
            return data;
        }

    }
}
