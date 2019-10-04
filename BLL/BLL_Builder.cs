using BLL.DTO;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BLL
{
    public static class BLL_Builder
    {
        public static IServiceCollection ConfigureBllDependencies(this IServiceCollection serviceCollection,
         Action<DbContextOptionsBuilder> optionsAction)
        {
            serviceCollection.ConfigureDalDependencies(optionsAction);
            serviceCollection.AddTransient<BLL_Main>();
            return serviceCollection;
        }
        public static StudentDTO CreateStudentDTO(int id, string firstname, string lastname, string groupName, string dormitoryName)
        {
            StudentDTO data = new StudentDTO
            {
                Id = id,
                Firstname = firstname,
                Lastname = lastname,
                GroupName = groupName,
                DormitoryName = dormitoryName

            };
            return data;
        }

        public static GroupDTO CreateGroupDTO(int id, string groupName)
        {
            GroupDTO data = new GroupDTO
            {
                Id = id,
                GroupName = groupName
            };
            return data;
        }

        public static DormitoryDTO CreateDormitoryDTO(int id, string dormitoryName)
        {
            DormitoryDTO data = new DormitoryDTO
            {
                Id = id,
                NameDormitory = dormitoryName
            };
            return data;
        }
    }
}
