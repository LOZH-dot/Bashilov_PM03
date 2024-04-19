using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bashilov_PM03
{
    class PersonnelManagement
    {
        public Person[] persons { get; private set; }

        public PersonnelManagement(int count)
        {
            if (count <= 0) throw new ArgumentException("Размер массива не может быть меньше или равен нулю!");
            persons = new Person[count];
        }

        public void Sort()
        {
            // Сортировка
            Person buf;
            for (int i = 0; i < persons.Length - 1; i++)
            {
                if (persons[i].YearOfBirth < persons[i + 1].YearOfBirth)
                {
                    buf = persons[i];
                    persons[i] = persons[i + 1];
                    persons[i + 1] = buf;
                }
                else if (persons[i].YearOfBirth == persons[i + 1].YearOfBirth)
                {
                    int compare = String.Compare(persons[i].Surname, persons[i + 1].Surname);
                    if (compare > 0)
                    {
                        buf = persons[i];
                        persons[i] = persons[i + 1];
                        persons[i + 1] = buf;
                    }
                }
            }

            //persons = persons.OrderByDescending(x => x.YearOfBirth).ThenBy(x => x.Surname).ToArray();
        }
    }
}
