using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bashilov_PM03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            int personsCount = 0;
            try
            {
                personsCount = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введено некорректное значение!");
                return;
            }

            PersonnelManagement pm;

            try
            {
                pm = new PersonnelManagement(personsCount);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            for (int i = 0; i < personsCount; i++)
            {
                Person nPerson = new Person();
                bool isCorrect = false;
                while (!isCorrect)
                {
                    Console.Write($"Введите фамилию для {i + 1}-го элемента массива: ");
                    nPerson.Surname = Console.ReadLine();
                    Console.Write($"Введите имя для {i + 1}-го элемента массива: ");
                    nPerson.Name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nPerson.Surname) || string.IsNullOrWhiteSpace(nPerson.Name))
                    {
                        Console.WriteLine("Значения фамилии или имени не могут быть пустыми!");
                        continue;
                    }

                    Console.Write($"Введите год рождения для {i + 1}-го элемента массива: ");
                    try
                    {
                        int _year = int.Parse(Console.ReadLine());
                        if (_year < 0) throw new ArgumentException("Год рождения не может быть меньше нуля!");
                        nPerson.YearOfBirth = _year;
                    }
                    catch (ArgumentException ar)
                    {
                        Console.WriteLine(ar.Message);
                        continue;
                    }
                    catch
                    {
                        Console.WriteLine("Введено некорректное значение года рождения!");
                        continue;
                    }
                    isCorrect = true;
                }

                pm.persons[i] = nPerson;
            }

            pm.Sort();

            for (int i = 0; i < pm.persons.Length; i++)
            {
                Console.WriteLine($"\nПорядковый номер: {i + 1}\nФамилия:{pm.persons[i].Surname}\nИмя:{pm.persons[i].Name}\nГод рождения:{pm.persons[i].YearOfBirth}");
            }

            pm.Save();
        }
    }
}
