using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.GC;
using static System.Exception;
using static System.Console;

//все объекты создаются в динамической управляемой памяти - куче, которая для удобства и эффективности работы сборщика мусора делится на 3 поколения: 0, 1 и 2.
//0 поколение занимает 256Кбайт
//1 поколение занимает 2Мбайт
//2 поколение занимает 10 Мбайт

namespace InterfacesWPU221
{
    //класс для создания мусора
    class GarbageHelper
    {
        //метод, создающий мусор
        public void MakeGarbage()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Person p = new Person();
            }
        }
        class Person
        {
            string _name;
            string _surname;
            byte _age;
        }
    }

    class GarbageCollector
    {
        static void Main(string[] args)
        {
            WriteLine("Демонстрация работы класса System.GC");
            WriteLine($"Максимальное поколение: {MaxGeneration}");

            GarbageHelper hlp = new GarbageHelper();
            WriteLine($"Поколение объекта: {GetGeneration(hlp)}");
            WriteLine($"Занято памяти (байт): {GetTotalMemory(false)}");
            hlp.MakeGarbage();
            WriteLine($"Занято памяти (байт): {GetTotalMemory(false)}");
            Collect(0);
            WriteLine($"Занято памяти (байт): {GetTotalMemory(false)}");
            WriteLine($"Поколение объекта: {GetGeneration(hlp)}");
            Collect();
            WriteLine($"Занято памяти (байт): {GetTotalMemory(false)}");
            WriteLine($"Поколение объекта: {GetGeneration(hlp)}");
        }
    }
}
