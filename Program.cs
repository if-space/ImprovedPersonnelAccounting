using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Lessons
{
    class Program
    {
        static Dictionary<string, List<string>> employeesByPosition = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            const string CommandAddEmployee = "1";
            const string CommandRemoveEmployee = "2";
            const string CommandDisplayInformation = "3";
            const string CommandExit = "4";

            bool isOpen = true;

            while (isOpen)
            {
                Console.Clear();

                Console.WriteLine($"Нажмите {CommandAddEmployee} чтобы добавить сотрудника");
                Console.WriteLine();
                Console.WriteLine($"Нажмите {CommandRemoveEmployee} чтобы удалить сотрудника");
                Console.WriteLine();
                Console.WriteLine($"Нажмите {CommandDisplayInformation} чтобы показать всех сотрудников");
                Console.WriteLine();
                Console.WriteLine($"Нажмите {CommandExit} чтобы выйти из программы");
                Console.WriteLine();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddEmployee:
                        Console.WriteLine("Введите должность: ");
                        string position = Console.ReadLine().ToLower();

                        Console.WriteLine("Введите ФИО: ");
                        string fullName = Console.ReadLine().ToLower();

                        AddEmployee(position, fullName);
                        break;

                    case CommandRemoveEmployee:
                        Console.WriteLine("Введите должность сотрудника: ");
                        position = Console.ReadLine().ToLower();

                        Console.WriteLine("Введите ФИО сотрудника: ");
                        fullName = Console.ReadLine().ToLower();

                        RemoveEmployee(position, fullName);
                        break;

                    case CommandDisplayInformation:
                        ShowAll(employeesByPosition);
                        break;

                    case CommandExit:
                        isOpen = false;
                        Console.WriteLine("Программа замершена");
                        break;

                    default:
                        Console.WriteLine("Введена неизвестная команда!!!");
                        break;
                }

                if (isOpen)
                {
                    Console.WriteLine("Нажмите на любую кнопку для возврата в меню...");
                    Console.ReadLine();
                }
            }
        }

        static void AddEmployee(string position, string fullName)
        {
            if (!employeesByPosition.TryGetValue(position, out List<string> employees))
            {
                employees = new List<string>();
                employeesByPosition.Add(position, employees);
            }

            employees.Add(fullName);
            Console.WriteLine("Сотрудник успешно добавлен!");
        }

        static void RemoveEmployee(string position, string fullName)
        {
            if (!employeesByPosition.TryGetValue(position, out List<string> employees))
            {
                Console.WriteLine("Должность не найдена");
                return;
            }

            if (!employees.Remove(fullName))
            {
                Console.WriteLine("Сотрудника нет на такой должности.");
                return;
            }

            if (employees.Count == 0)
            {
                employeesByPosition.Remove(position);
            }

            Console.WriteLine("Сотрудник удален");
        }

        static void ShowAll(Dictionary<string, List<string>> employes)
        {
            if (employeesByPosition.Count == 0)
            {
                Console.WriteLine("Сотрудников пока еще нет");
                return;
            }

            foreach (var employee in employeesByPosition)
            {
                Console.WriteLine($"Должность: {employee.Key}");

                foreach (var name in employee.Value)
                {
                    Console.WriteLine($"Имя: {name}");
                }
            }
        }
    }
}