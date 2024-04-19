using System;
using System.Collections.Generic;
using System.IO;
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
            for (int i = 0; i < persons.Length; i++)
            {
                for (int j = 0; j < persons.Length - 1; j++)
                {
                    if (persons[j].YearOfBirth > persons[j + 1].YearOfBirth)
                    {
                        buf = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j + 1] = buf;
                    }
                    else if (persons[j].YearOfBirth == persons[j + 1].YearOfBirth)
                    {
                        int compare = String.Compare(persons[j].Surname, persons[j + 1].Surname, false);
                        if (compare < 0)
                        {
                            buf = persons[j];
                            persons[j] = persons[j + 1];
                            persons[j + 1] = buf;
                        }
                    }
                }
            }

            Array.Reverse(persons);
        }
        
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter("./result.txt"))
            {
                for (int i = 0; i < persons.Length; i++)
                {
                    sw.WriteLine($"Порядковый номер: {i + 1}\nФамилия:{persons[i].Surname}\nИмя:{persons[i].Name}\nГод рождения:{persons[i].YearOfBirth}\n");
                }
            }
        }
    }
}
