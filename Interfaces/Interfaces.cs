using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//синтаксис интерфейса
/*[модификатор_доступа] interface имя_интерфейса
{
    //члены интерфейса
}*/

namespace InterfacesWPU221
{
    public interface IWorker
    {
        bool IsWorking { get; }
        string Work();
    }

    public interface IManager
    {
        List<IWorker> ListOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();
    }

    abstract class Human
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }

        public override string ToString()
        {
            return $"Имя: {firstName}\nФамилия: {lastName}\nДата рождения: {birthDate.ToLongDateString()}";
        }
    }

    abstract class Employee : Human
    {
        public string position { get; set; }
        public double salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nДолжность: {position}\nЗарплата: {salary}\n";
        }
    }

    class Director : Employee, IManager
    {
        public List<IWorker> ListOfWorkers { get; set; }
        public void Organize()
        {
            WriteLine("Я организую работу магазина и сотрудников");
        }
        public void MakeBudget()
        {
            WriteLine("Я формирую бюджет");
        }
        public void Control()
        {
            WriteLine("Я контролирую работу магазина и сотрудников");
        }
    }

    class Seller : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        public string Work()
        {
            return "Я продаю товар";
        }
    }

    class Cashier : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        public string Work()
        {
            return "Принимаю оплату за товар";
        }
    }

    class Storekeeper : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        public string Work()
        {
            return "Я принимаю и учитываю товар";
        }
    }

    class InterfacesWPU221
    {
        static void Main(string[] args)
        {
            Director director = new Director
            {
                firstName = "Ray",
                lastName = "Crock",
                birthDate = new DateTime(1945, 12, 12),
                position = "Директор",
                salary = 50000.0
            };

            IWorker seller = new Seller
            {
                firstName = "Jim",
                lastName = "Seller",
                birthDate = new DateTime(1988, 11, 05),
                position = "Продавец",
                salary = 5000
            };

            if(seller is Employee)
            {
                WriteLine($"Заработная плата продавца: {(seller as Employee).salary}");
            }

            director.ListOfWorkers = new List<IWorker>
            {
                seller,
                new Cashier
                {
                    firstName="Elena",
                    lastName="Anatoljevna",
                    birthDate=new DateTime(1917, 10, 15),
                    position="Кассир",
                    salary=10000
                },
                new Storekeeper
                {
                    firstName="Albert",
                    lastName="Stepanovich",
                    birthDate=new DateTime(1799,05,09),
                    position="Хранитель",
                    salary=15000
                }
            };

            WriteLine(director);
            if(director is IManager)
            {
                director.Control();
            }

            foreach(IWorker item in director.ListOfWorkers)
            {
                WriteLine(item);
                if(item.IsWorking)
                {
                    WriteLine(item.Work());
                }
            }

        }
    }
}