using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddEmployee = "1";
            const string CommandRemoveEmployee = "2";
            const string CommandDysplayInformation = "3";
            const string CommandExit = "4";

            Dictionary<string, List<string>> employeByPosition = new Dictionary<string, List<string>>();

            bool isOpen = true;


            while (isOpen)
            {
                Console.WriteLine($"Нажмите {CommandAddEmployee} чтобы добавить сотрудника");
                Console.WriteLine();
                Console.WriteLine($"Нажмите {CommandRemoveEmployee} чтобы удалить сотрудника");
                Console.WriteLine();
                Console.WriteLine($"Нажмите {CommandDysplayInformation} чтобы показать всех сотрудников");
                Console.WriteLine();
                Console.WriteLine($"Нажмите {CommandExit} чтобы выйти из программы");
                Console.WriteLine();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddEmployee:
                        AddEmployee(employeByPosition);
                        break;

                    case CommandRemoveEmployee:
                        RemoveEmployee(employeByPosition);
                        break;

                    case CommandDysplayInformation:
                        ShowAll(employeByPosition);
                        break;

                    case CommandExit:
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Введена неизвестная команда");
                        break;
                }
            }
        }

        static void AddEmployee(Dictionary<string, List<string>> employeesByPosition)
        {
            Console.WriteLine("Введите должность: ");
            string position = Console.ReadLine().ToLower();

            Console.WriteLine("Введите ФИО: ");
            string fullName = Console.ReadLine().ToLower();

            if (!employeesByPosition.TryGetValue(position, out List<string> employes))
            {
                employes = new List<string>();
                employeesByPosition.Add(position, employes);
            }

            employes.Add(fullName);
        }

        static void RemoveEmployee(Dictionary<string, List<string>> employessByPosition)
        {
            Console.Write("Введите должность сотрудника: ");
            string position = Console.ReadLine().ToLower();

            if (!employessByPosition.TryGetValue(position, out List<string> employes))
            {
                Console.WriteLine("Такой должности нет!");
                return;
            }

            Console.Write("Введите ФИО сотрудника: ");
            string fullName = Console.ReadLine();

            if (!employes.Remove(fullName))
            {
                Console.WriteLine("Такого сотрудника на этой должности нет");
                return;
            }

            if (employes.Count == 0)
            {
                employessByPosition.Remove(position);
            }

            Console.WriteLine("Сотрудник удален!");
        }

        static void ShowAll(Dictionary<string, List<string>> employessByPosition)
        {
            if (employessByPosition.Count == 0)
            {
                Console.WriteLine("Сотрудников пока нет!");
                return;
            }

            foreach (var employe in employessByPosition)
            {
                Console.WriteLine($"Должность: {employe.Key}");

                foreach (var name in employe.Value)
                {
                    Console.WriteLine($"Имя: {name}");
                }
            }
        }
    }
}
