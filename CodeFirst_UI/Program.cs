using System;
using BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static BLL.MappService;
using DAL.Models;

namespace CodeFirst_UI
{
    class Program
    {
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("jsonPath.json")
            .Build();
            var serviceCollection = new ServiceCollection()
                .ConfigureBllDependencies(options => options
                .UseSqlServer(configuration.GetConnectionString("default")));
            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var blService = serviceProvider.GetService<EntitiesOperationsService>();
           
            int userInput;
        Start:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Constans.StarterMenu);
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput > Constans.CountStarterOperations)
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
                    var allStudents = blService.GetAllStudents();
                    foreach(Student a in allStudents)
                    {
                        Console.WriteLine($"{a.Firstname} {a.Lastname} {a.Group.GroupName} {a.Dormitory?.NameDormitory ?? "No dormitory"}");
                    }
                    Console.WriteLine("\n");
                    goto Start;
                }

                else if(inputForStudent == 2)
                {
                    var allStudents = blService.GetAllStudentsWithoutDormitory();
                    foreach(Student a in allStudents)
                    {
                        Console.WriteLine($"{a.Firstname} {a.Lastname} {a.Group.GroupName} {a.Dormitory?.NameDormitory ?? "No dormitory"}");
                    }
                    Console.WriteLine("\n");
                    goto Start;
                }

                else if (inputForStudent == 3)
                {
                    var allStudents = blService.GetAllStudentsWithDormitory();
                    foreach(Student a in allStudents)
                    {
                        Console.WriteLine($"{a.Firstname} {a.Lastname} {a.Group.GroupName} {a.Dormitory?.NameDormitory ?? "No dormitory"}");
                    }
                    Console.WriteLine("\n");
                    goto Start;
                }

                else if (inputForStudent == 4)
                {
                    int maxGroupId = blService.CountNumberGroups();
                    int maxDormitoryId = blService.CountNumberDormitories();
                    
                    string studFirstname;
                    string studLastname;
                    int @group;
                    int? dormitory;

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
                        Console.WriteLine($"Id групи(максимальне ID = {maxGroupId}): ");
                        @group = Convert.ToInt32(Console.ReadLine());
                        if(Convert.ToInt32(@group) > maxGroupId)
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
                        Console.WriteLine($"Id гуртожитку(максимальне ID = {maxDormitoryId}, або \"null\"): ");
                        string dormitoryInput = Console.ReadLine();
                        if (dormitoryInput == "null")
                        {
                            dormitory = 1                               ;
                        }
                        else
                        {
                            dormitory = Convert.ToInt32(dormitoryInput);
                                if (dormitory > maxDormitoryId) 
                                {
                                    throw new Exception();
                                }
                        }
  
                    }
                    catch
                    {
                        Console.WriteLine(Constans.InvalidValue);
                        goto InvalidDormitory;
                    }
                    blService.AddStudent(CreateStudentDto(studFirstname, studLastname, @group, dormitory));

                    if (!Constans.StarterMenu.Contains("4. Зберегти зміни"))
                    {
                        Constans.StarterMenu += "4. Зберегти зміни";
                        Constans.CountStarterOperations++;
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
                    if(inputForGroup > Constans.CountGroupOperations)
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
                    blService.AddGroup(CreateGroupDto(groupNameInput));
                    if (!Constans.StarterMenu.Contains("4. Зберегти зміни"))
                    {
                        Constans.StarterMenu += "4. Зберегти зміни";
                        Constans.CountStarterOperations++;
                    }
                    goto Start;
                }
                else if (inputForGroup == 2)
                {
                    var groups = blService.GetAllGroups();
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
                    if(inputForDormitories > Constans.CountDormitoriesOperations)
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
                    blService.AddDormitory(CreateDormitoryDto(dormitoryNameInput));
                    if (!Constans.StarterMenu.Contains("4. Зберегти зміни"))
                    {
                        Constans.StarterMenu += "4. Зберегти зміни";
                        Constans.CountStarterOperations++;
                    }
                    goto Start;
                }
                else if (inputForDormitories == 2)
                {
                    var dormitories = blService.GetAllDormitories();
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
                blService.SaveChanges();
                goto Start;
            }
        }
    }
}