using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace InterfacesWPU221
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: {Series} {Number}\n";
        }
    }

    class Student : IComparable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string group { get; set; }
        public string city { get; set; }
        public string zodiacSign { get; set; }
        public StudentCard StudentCard { get; set; }
        

        public override string ToString()
        {
            return $"Имя: {firstName}\nФамилия: {lastName}\nДата рождения: {birthDate.ToLongDateString()}\nФакультет: {group}\nГород рождения: {city}\nЗнак зодиака: {zodiacSign}\n" + StudentCard.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return lastName.CompareTo((obj as Student).lastName);
            }
            throw new NotImplementedException();
        }
    }

    class Auditory : IEnumerable
    {
        Student[] students =
        {
            new Student
            {
                firstName="Harry",
                lastName="Potter",
                birthDate=new DateTime(1981,07,31),
                group="Griffindor",
                city="London",
                zodiacSign="Taurus",
                StudentCard=new StudentCard
                {
                    Number=19810731,
                    Series="HP"
                }
            },
            new Student
            {
                firstName="Drako",
                lastName="Malfoy",
                birthDate=new DateTime(1981,10,23),
                group="Slitherin",
                city="Birmingham",
                zodiacSign="Leo",
                StudentCard=new StudentCard
                {
                    Number=19811023,
                    Series="DM"
                }
            },
            new Student
            {
                firstName="Polumna",
                lastName="Lovegood",
                birthDate=new DateTime(1985,03,15),
                group="Hufflepuff",
                city="Leeds",
                zodiacSign="Scorpio",
                StudentCard=new StudentCard
                {
                    Number=19850315,
                    Series="PL"
                }
            },
            new Student
            {
                firstName="Cedrick",
                lastName="Diggory",
                birthDate=new DateTime(1980,09,25),
                group="Ravenclaw",
                city="Sheffield",
                zodiacSign="Aries",
                StudentCard=new StudentCard
                {
                    Number=19800925,
                    Series="CD"
                }
            },
            new Student
            {
                firstName="Ron",
                lastName="Weasley",
                birthDate=new DateTime(1980,03,01),
                group="Griffindor",
                city="Manchester",
                zodiacSign="Virgo",
                StudentCard=new StudentCard
                {
                    Number=64537846,
                    Series="BD"
                }
            },
            new Student
            {
                firstName="Hermione",
                lastName="Granger",
                birthDate=new DateTime(1979,09,19),
                group="Griffindor",
                city="Liverpool",
                zodiacSign="Libra",
                StudentCard=new StudentCard
                {
                    Number=19640857,
                    Series="BC"
                }
            },
            new Student
            {
                firstName="Vincent",
                lastName="Crabbe",
                birthDate=new DateTime(1979,12,29),
                group="Slitherin",
                city="Bristol",
                zodiacSign="Gemini",
                StudentCard=new StudentCard
                {
                    Number=28063784,
                    Series="AC"
                }
            },
            new Student
            {
                firstName="Zacharias",
                lastName="Smith",
                birthDate=new DateTime(1980,02,21),
                group="Hufflepuff",
                city="Coventry",
                zodiacSign="Aquarius",
                StudentCard=new StudentCard
                {
                    Number=70893045,
                    Series="RC"
                }
            },
            new Student
            {
                firstName="Cho",
                lastName="Chang",
                birthDate=new DateTime(1980,05,06),
                group="Ravenclaw",
                city="Bradford",
                zodiacSign="Aries",
                StudentCard=new StudentCard
                {
                    Number=00468976,
                    Series="RL"
                }
            },
            new Student
            {
                firstName="Pansy",
                lastName="Parkinson",
                birthDate=new DateTime(1979,10,13),
                group="Slitherin",
                city="Nottingham",
                zodiacSign="Taurus",
                StudentCard=new StudentCard
                {
                    Number=10985176,
                    Series="RB"
                }
            },

        };

        public void Sort()
        {
            Array.Sort(students);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }

    class DataComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).birthDate, (y as Student).birthDate);
            }
            throw new NotImplementedException();
        }
    }
    
    class firstNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).firstName, (y as Student).firstName);
            }
            throw new NotImplementedException();
        }
    }
    
    class groupComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).group, (y as Student).group);
            }
            throw new NotImplementedException();
        }
    }
    
    class cityComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).city, (y as Student).city);
            }
            throw new NotImplementedException();
        }
    }
    
    class zodiacSignComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return string.Compare((x as Student).zodiacSign, (y as Student).zodiacSign);
            }
            throw new NotImplementedException();
        }
    }
    

    class InterfacesWPU221
    {
        static void Main(string[] args)
        {
            Auditory auditory = new Auditory();
            WriteLine("************Список студентов*****************");
            WriteLine();
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
            WriteLine("***********Сортировка по фамилии************");
            WriteLine();
            auditory.Sort();
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***********Сортировка по дате рождения************");
            WriteLine();
            auditory.Sort(new DataComparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***********Сортировка по имени************");
            WriteLine();
            auditory.Sort(new firstNameComparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***********Сортировка по факультету************");
            WriteLine();
            auditory.Sort(new groupComparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***********Сортировка по городу рождения************");
            WriteLine();
            auditory.Sort(new cityComparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***********Сортировка по знаку зодиака************");
            WriteLine();
            auditory.Sort(new zodiacSignComparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
        }
    }
}