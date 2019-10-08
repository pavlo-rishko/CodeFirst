using System;
using BLL.DTO;
using BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static BLL.MappService;
using DAL;

namespace CodeFirst_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("jsonPath.json")
            .Build();
            var serviceCollection = new ServiceCollection()
                .ConfigureBllDependencies(options => options
                .UseSqlServer(configuration.GetConnectionString("default")));
            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var BL_Service = serviceProvider.GetService<EntitiesOperationsService>();
           
            int userInput;
        Start:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Constans.StarterMenu);
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput > Constans.countStarterOperations)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Будь ласка, вводіть тільки цифру конкретної операції\n");
                Console.ReadKey();
                goto Start;
            }
           
            StudentMenu:
            if(userInput == 1)
            {
                int inputForStudent;
                Console.WriteLine(Constans.StudentMenu);
                try
                {
                    inputForStudent = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    goto StudentMenu;
                }
                if(inputForStudent == 1)
                {
                    var allStudents = BL_Service.GetAllStudents();
                    foreach(Student a in allStudents)
                    {
                        Console.WriteLine($"{a.Firstname} {a.Lastname} {a.Group.GroupName} {a.Dormitory?.NameDormitory ?? "No dormitory"}");
                    }
                    Console.WriteLine("\n");
                    goto Start;
                }

                else if(inputForStudent == 2)
                {
                    var allStudents = BL_Service.GetAllStudentsWithoutDormitory();
                    foreach(Student a in allStudents)
                    {
                        Console.WriteLine($"{a.Firstname} {a.Lastname} {a.Group.GroupName} {a.Dormitory?.NameDormitory ?? "No dormitory"}");
                    }
                    Console.WriteLine("\n");
                    goto Start;
                }

                else if (inputForStudent == 3)
                {
                    var allStudents = BL_Service.GetAllStudentsWithDormitory();
                    foreach(Student a in allStudents)
                    {
                        Console.WriteLine($"{a.Firstname} {a.Lastname} {a.Group.GroupName} {a.Dormitory?.NameDormitory ?? "No dormitory"}");
                    }
                    Console.WriteLine("\n");
                    goto Start;
                }

                else if (inputForStudent == 4)
                {
                    int maxGroupID = BL_Service.CountNumberGroups();
                    int maxDormitoryID = BL_Service.CountNumberDormitories();
                    
                    string studFirstname;
                    string studLastname;
                    string Group;
                    string Dormitory;

                    InvalidFirstname: 
                    Console.WriteLine("Будь ласка введіть дані студента:\nІм'я: ");
                    try
                    {
                        studFirstname = Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine(Constans.InvalidValue);
                        goto InvalidFirstname;
                    }

                    InvalidLastname:
                    try
                    {
                        Console.WriteLine("Прізвище: ");
                        studLastname = Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine(Constans.InvalidValue);
                        goto InvalidLastname;
                    }

                    IvalidGroup:
                    try
                    {
                        Console.WriteLine($"Id групи(максимальне ID = {maxGroupID}): ");
                        Group = Console.ReadLine();
                        if(Convert.ToInt32(Group) > maxGroupID)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.WriteLine(Constans.InvalidValue);
                        goto IvalidGroup;
                    }

                    InvalidDormitory:
                    try
                    {
                        Console.WriteLine($"Id гуртожитку(максимальне ID = {maxDormitoryID}): ");                        
                        Dormitory = Console.ReadLine();
                        if (Convert.ToInt32(Dormitory) > maxDormitoryID)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.WriteLine(Constans.InvalidValue);
                        goto InvalidDormitory;
                    }
                    BL_Service.AddStudent(CreateStudentDTO(studFirstname, studLastname, Group, Dormitory));

                    if (!Constans.StarterMenu.Contains("4. Зберегти зміни"))
                    {
                        Constans.StarterMenu += "4. Зберегти зміни";
                        Constans.countStarterOperations++;
                    }                    
                    
                    goto Start;
                }
                else if(inputForStudent == 0)
                {
                    goto Start;
                }
                else
                {
                    goto StudentMenu;
                }
            }
            else if(userInput == 2)
            {
                int inputForGroup;
                InvalidCommandGroup:
                Console.WriteLine(Constans.GroupMenu);
                try
                {
                    inputForGroup = Convert.ToInt32(Console.ReadLine());
                    if(inputForGroup > Constans.countGroupOperations)
                    {
                        goto InvalidCommandGroup;
                    }
                }
                catch
                {
                    Console.WriteLine(Constans.InvalidValue);
                    goto InvalidCommandGroup;
                }
                if (inputForGroup == 1)
                {
                    string groupNameInput;
                InvalidValue:
                   
                        Console.WriteLine("Введіть будь ласка назву групи");
                    try
                    {
                        groupNameInput = Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine("Не вірне введення");
                        goto InvalidValue;
                    }
                    BL_Service.AddGroup(CreateGroupDTO(groupNameInput));
                    if (!Constans.StarterMenu.Contains("4. Зберегти зміни"))
                    {
                        Constans.StarterMenu += "4. Зберегти зміни";
                        Constans.countStarterOperations++;
                    }
                    goto Start;
                }
                else if (inputForGroup == 2)
                {
                    var groups = BL_Service.GetAllGroups();
                    foreach(Group a in groups)
                    {
                        Console.WriteLine($"{a.Id}. {a.GroupName}");
                    }

                    goto Start;
                }
                else if (inputForGroup == 0)
                {
                    goto Start;
                }
                else
                {
                    goto InvalidCommandGroup;
                }
            }
            else if(userInput == 3)
            {
                int inputForDormitories;
                string dormitoryNameInput;
            InvalidValue:
                Console.WriteLine(Constans.DormitoryMenu);
                try
                {
                    inputForDormitories = Convert.ToInt32(Console.ReadLine());
                    if(inputForDormitories > Constans.countDormitoriesOperations)
                    {
                        goto InvalidValue;
                    }
                }
                catch
                {
                    goto InvalidValue;
                }
                if(inputForDormitories == 1)
                {
                    Console.WriteLine("Введіть будь ласка назву групи");
                    try
                    {
                        dormitoryNameInput = Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine("Не вірне введення");
                        goto InvalidValue;
                    }
                    BL_Service.AddDormitory(CreateDormitoryDTO(dormitoryNameInput));
                    if (!Constans.StarterMenu.Contains("4. Зберегти зміни"))
                    {
                        Constans.StarterMenu += "4. Зберегти зміни";
                        Constans.countStarterOperations++;
                    }
                    goto Start;
                }
                else if (inputForDormitories == 2)
                {
                    var dormitories = BL_Service.GetAllDormitories();
                    foreach(Dormitory a in dormitories)
                    {
                        Console.WriteLine($"{a.Id} {a.NameDormitory}");
                    }
                    goto Start;
                }
                else if (inputForDormitories == 0)
                {
                    goto Start;
                }
                else
                {
                    goto InvalidValue;
                }
            }
            else if(userInput == 4)
            {
                BL_Service.SaveChanges();
                goto Start;
            }
        }
    }
}