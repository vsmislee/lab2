using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Money money1 = new Money(200, 20);//money1 инициализация
                Console.WriteLine("Money1: ");
                Console.WriteLine(money1.ToString());// вызываем тостринг, потому что, если не вызывать, то неявно приводится к типу uint и выводит только рубли
                Console.Write("Money1++: ");
                money1++;
                Console.WriteLine(money1.ToString());
                Console.Write("Money1--: ");
                money1--;
                Console.WriteLine(money1.ToString());
                Console.WriteLine();

                Money money2 = new Money();//money2 создание и инициализация конструктором без параметров
                Console.WriteLine("Money2: ");
                Console.WriteLine(money2.ToString());
                Console.WriteLine();

                Console.WriteLine("Money2 новые значения: "); // money2 ввод новых значений
                Console.Write("Рубли: ");
                money2.Rubles = uint.Parse(Console.ReadLine());
                Console.Write("Копейки: ");
                money2.Kopeks = byte.Parse(Console.ReadLine());
                Console.WriteLine();

                money1 = money1.Minus(money2); // демонстрация метода minus
                Console.WriteLine("Money1 = Money1 - Money2: ");
                Console.WriteLine(money1.ToString());
                uint rub = money1; // неявное приведение к uint
                Console.WriteLine("Рубли: " + rub);
                double kop = (double)money1; // явное приведение к double
                Console.WriteLine("Рубли: " + kop);
                Console.WriteLine();

                Money money3 = new Money(); // money3 создание и инициализация 
                money3 = money1 - 50; // демонстрация правостороннего оператора ' - '
                Console.WriteLine("Money3 = Money1 - 50: ");
                Console.WriteLine(money3.ToString());
                Console.WriteLine();
                Console.WriteLine("Money3 = 300 - Money1: "); // демонстрация левостороннего оператора ' - '
                money3 = 300 - money1;
                Console.WriteLine(money3.ToString());
                Console.WriteLine();

                money3 = money3 - money1; // демонстрация оператора ' - ' 
                Console.WriteLine("Money3 = Money3 - Money1: ");
                Console.WriteLine(money3.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);            
            }
        }
    }
}
