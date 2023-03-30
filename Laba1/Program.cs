using ConsoleApp.PostgreSQL;
using Laba1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!");
            while (true)
            {
            Console.WriteLine("Выберите функцию:");
            Console.WriteLine("1-Создать");
            Console.WriteLine("2-Удалить");
            Console.WriteLine("3-Обновить");
            Console.WriteLine("4-Проверить");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите название теста:");
                    string n = Console.ReadLine();
                    Console.WriteLine("Введите баллы:");
                    int a = Int32.Parse(Console.ReadLine());
                    using (BloggingContext context = new BloggingContext())
                    {
                        context.Tests.Add(new Test() { Name = n, Mark = a });
                        context.SaveChanges();
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите ID теста:");
                    int i = Int32.Parse(Console.ReadLine());
                    using (BloggingContext context = new BloggingContext())
                    {
                        var userToDelete = context.Tests.Find(i);
                        if (userToDelete != null)
                        {
                            Console.WriteLine($"Вы действительно хотите удалить тест {userToDelete.Name}? (Y/N)");
                            var key = Console.ReadKey().Key;
                            if (key == ConsoleKey.Y)
                            {
                                context.Tests.Remove(userToDelete);
                                    context.SaveChanges();
                                Console.WriteLine( $"\nТест {userToDelete.Name} удален из базы данных.");
                            }
                            else
                            {
                                Console.WriteLine($"Удаление теста {userToDelete.Name} отменено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Тест с идентификатором {i} не найден в базе данных.");
                        }
                    }
                    break;
                    case 3:
                    Console.WriteLine("Введите ID теста:");
                    int i1 = Int32.Parse(Console.ReadLine());
                    using (BloggingContext context = new BloggingContext())
                    {
                            var userToUpdate = context.Tests.Find(i1);
                            if (userToUpdate != null)
                            {
                                Console.WriteLine($"Введите новую дисциплину для теста {userToUpdate.Name}:");
                                userToUpdate.Name = Console.ReadLine();
                                Console.WriteLine($"Введите новые баллы для теста {userToUpdate.Mark}:");
                                userToUpdate.Mark = Int32.Parse(Console.ReadLine());
                                context.SaveChanges();
                                Console.WriteLine($"Данные теста {userToUpdate.Name} успешно обновлены.");
                                Console.WriteLine($"Данные теста {userToUpdate.Mark} успешно обновлены.");
                            }
                            else
                            {
                                Console.WriteLine($"Тест с идентификатором {i1} не найден в базе данных.");
                            }
                        
                        break;
                    }
                    case 4:
                    using (BloggingContext context = new BloggingContext())
                    {
                        var users = context.Tests.ToList();
                        Console.WriteLine("Список тестов:");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"{user.Id}: {user.Name} {user.Mark}");
                        }
                    }
                    break;
            }

                Console.WriteLine("Хотите запустить программу заново? (Y/N)");
                var input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break; 
                }
            }
        }
    }
}