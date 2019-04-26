using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Reflection;
using System.Data.SqlClient;
using DbUp;
using Exam.DataAccess;
using Exam.Models;

namespace Exam.ConsoleApp
{
    class Program
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;

        static void Main(string[] args)
        {
            CheckMigrations();

            while (true)
            {
                Console.WriteLine("Выберите с чем работать\n1 - Страны\n2 - Города\n3 - Улицы\n4 - Выход");
                int answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1: CountriesWork(); break;
                    case 2: break;
                    case 3: break;
                    case 4: Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Такого варианта нет");
                        break;
                }
            }

        }

        private static void CountriesWork()
        {
            while (true)
            {

                Console.WriteLine("Выберите действие\n1 - Посмотреть страны\n2 - Добавить страну\n3 - Редактировать страну\n4 - Удалить страну");
                int answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        using (var repository = new CountriesRepository())
                        {
                            var countries = repository.Select();
                            foreach(var country in countries)
                                Console.WriteLine($"{country.Name} - {country.Population} человек");
                        } break;
                    case 2:
                        using (var repository = new CountriesRepository())
                        {
                            var newCountry = new Country();
                            while(newCountry.Name == null || newCountry.Name == string.Empty)
                            {
                                Console.Write("Введите название: ");
                                newCountry.Name = Console.ReadLine();
                            }
                            while (newCountry.Population < 0)
                            {
                                Console.Write("Введите численность населения: ");
                                newCountry.Population = int.Parse(Console.ReadLine());
                            }
                            newCountry.CreationDate = DateTime.Now;
                            repository.Insert(newCountry);
                        }
                        break;
                    case 3: break;
                    case 4: break;
                    default:
                        Console.WriteLine("Нет такого варианта");
                        break;
                }
            }
        }

        private static void CheckMigrations()
        {
            EnsureDatabase.For.SqlDatabase(_connectionString);

            var upgrader = DeployChanges.To
            .SqlDatabase(_connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful) throw new Exception("Ошибка соединения");
        }
    }
}
