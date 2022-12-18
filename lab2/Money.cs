using System;

namespace lab2
{
    class Money
    {
        uint rubles;
        byte kopeks;

        public Money()// конструктор без параметров 
        {
            this.rubles = 0;
            this.kopeks = 0;
        }

        public Money(uint rubles, byte kopeks)// конструктор с параметрами
        {
            this.Rubles = rubles;
            this.Kopeks = kopeks;
        }

        public uint Rubles // свойство для доступа к полю rubles
        {
            get { return this.rubles; }
            set {
                if (value < 0)
                    throw new Exception("Ошибка! Введено отрицательное значение!");
                this.rubles = value; 
            }
        }

        public byte Kopeks // свойство для доступа к полю kopeks
        {
            get { return this.kopeks; }
            set {
                if (value < 0)
                    throw new Exception("Ошибка! Введено отрицательное значение!");
                else if (value >= 100)
                {
                    rubles++;
                    this.kopeks = (byte)(value - 100);
                }
                else this.kopeks = value;
             }
        }

        public override string ToString() // переопределение функции ToString
        {
            return "Рубли: " + this.rubles+ "; Копейки: " + this.kopeks + ";";
        }

        public Money Minus(Money money) // метод вычитающий объект типа money из вызывающего объекта
        {
            Money res;
            if ((this.rubles - money.rubles) < 0)
                throw new Exception("Ошибка! Отрицательное значение!");
            if (this.kopeks < money.kopeks)
            {
                this.rubles--;
                res = new Money(this.rubles - money.rubles, (byte)(100 + this.kopeks - money.kopeks));
            }
            else res = new Money(this.rubles - money.rubles, (byte)(this.kopeks - money.kopeks));
            return res;
        }

        public static Money operator ++(Money money) // увеличение копеек на еденицу
        {
            money.Kopeks++;
            return money;
        }

        public static Money operator --(Money money) // уменьшение копеек на еденицу
        {
            if (money.Kopeks == 0)
            {
                money.Rubles--;
                money.Kopeks = 100 - 1;
                return money;
            }
            money.Kopeks--;
            return money;
        }

        public static implicit operator uint(Money money) // неявное преобразование к uint
        {
            return money.rubles;
        }

        public static explicit operator double(Money money) // явное преобразование к double
        {
            return (double)money.Kopeks/100;
        }

        public static Money operator-(Money m, uint n) // оператор вычитания из объекта тип Money целого числа без знака
        {
            if (m.Rubles < n)
                throw new Exception("Ошибка! Отрицательное значение!");
            Money res = new Money(m.rubles - n, m.kopeks);
            return res;
        }

        public static Money operator -(uint n, Money m) // оператор вычитания из целого числа без знака объекта типа Money
        {
            Money res;
            if (n < m.rubles)
                throw new Exception("Ошибка! Отрицательное значение!");
            if (m.kopeks != 0)
            {
                n--;
                res = new Money(n - m.rubles, (byte)(100 - m.kopeks));
            }
            else 
                res = new Money(n - m.rubles, m.kopeks);
            return res;
            
        }

        public static Money operator -(Money m1, Money m2) // оператор разности двух объектов типа Money
        {
            return m1.Minus(m2);
        }
    }
}
