using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentCount = StudentCount();
            if (studentCount == 0)
            {
                Console.WriteLine("Отсутствуют объекты.");
                return;
            }

            // Получаем данные о студентах
            List<Student> students = GetStudentsData(studentCount);

            // Вывод данных о студентах
            DisplayStudentsData(students);

            // Вывод среднего балла по каждому предмету
            DisplayAverageGrades(students);

            // Вывод студентов с средним баллом выше 4
            DisplayStudentsAboveAverage(students);
            Console.ReadLine();
        }

        // Метод для получения количества студентов
        static int StudentCount()
        {
            Console.WriteLine("Введите количество студентов: ");
            return int.TryParse(Console.ReadLine(), out int count) && count > 0 ? count : 0;
        }

        // Метод для ввода данных о студентах
        static List<Student> GetStudentsData(int count)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nВведите данные для студента {i + 1}:");
                Student student = new Student
                {
                    FIO = GetStringInput("ФИО: "),
                    Group = GetStringInput("Группа: "),
                    Informatics = GetGradeInput("Оценка по информатике: "),
                    Physics = GetGradeInput("Оценка по физике: "),
                    History = GetGradeInput("Оценка по истории: ")
                };

                students.Add(student);
            }

            return students;
        }

        // Метод для ввода строковых данных
        static string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // Метод для ввода оценки (целое число)
        static int GetGradeInput(string prompt)
        {
            int grade;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out grade) && grade >= 1 && grade <= 5)
                {
                    return grade;
                }
                Console.WriteLine("Ошибка: введите оценку от 1 до 5.");
            }
        }

        // Метод для вывода данных о студентах
        static void DisplayStudentsData(List<Student> students)
        {
            Console.WriteLine("\nДанные о студентах:");
            Console.WriteLine("ФИО\t\t\tГруппа\tИнформатика\tФизика\tИстория");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FIO}\t{student.Group}\t{student.Informatics}\t\t{student.Physics}\t{student.History}");
            }
        }

        // Метод для вычисления и вывода среднего балла по каждому предмету
        static void DisplayAverageGrades(List<Student> students)
        {
            double avgInformatics = students.Average(s => s.Informatics);
            double avgPhysics = students.Average(s => s.Physics);
            double avgHistory = students.Average(s => s.History);

            Console.WriteLine($"\nСредний балл по информатике: {avgInformatics:F2}");
            Console.WriteLine($"Средний балл по физике: {avgPhysics:F2}");
            Console.WriteLine($"Средний балл по истории: {avgHistory:F2}");
        }

        // Метод для вывода студентов с средним баллом выше 4
        static void DisplayStudentsAboveAverage(List<Student> students)
        {
            var aboveFour = students.Where(s => (s.Informatics + s.Physics + s.History) / 3.0 > 4).ToList();

            if (aboveFour.Count > 0)
            {
                Console.WriteLine("\nСтуденты с средним баллом выше 4:");
                foreach (var student in aboveFour)
                {
                    Console.WriteLine($"{student.FIO} (Средний балл: {(student.Informatics + student.Physics + student.History) / 3.0:F2})");
                }
            }
            else
            {
                Console.WriteLine("\nНет студентов с средним баллом выше 4.");
            }

            Console.WriteLine($"\nКоличество студентов с средним баллом выше 4: {aboveFour.Count}");
        }
    }
}

    

