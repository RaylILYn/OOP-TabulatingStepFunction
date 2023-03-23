// Задание 2.1 [Вариант 2]
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Console5
{
    class Table
    {
        // Закрытые поля: заголовок таблицы, заголовки столбцов
        string header, header0, header1;
        // Закрытые поля: ширина первого и второго столбцов
        int width0, width1;

        // Конструктор с параметрами
        public Table(string h, string h0, string h1, int w0, int w1)
        {
            header = h;
            header0 = h0;
            header1 = h1;
            width0 = w0;
            width1 = w1;
        }
        // Свойства доступа к закрытым полям
        public string hdr
        {
            set { header = value; }
            get { return header; }
        }
        public string hdr0
        {
            set { header0 = value; }
            get { return header0; }
        }
        public string hdr1
        {
            set { header1 = value; }
            get { return header1; }
        }
        public int wd0
        {
            set { width0 = value; }
            get { return width0; }
        }
        public int wd1
        {
            set { width1 = value; }
            get { return width1; }
        }

        // Метод для вывода шапки таблицы
        public void Hat()
        {
            Console.WriteLine("\nТаблица:\n" + header);
            Console.Write("╔");
            for (int i = 0; i < width0; i++) Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < width1; i++) Console.Write("═");
            Console.WriteLine("╗");
            string s = "║{0,-" + width0.ToString() + "}║{1,-" + width1.ToString() + "}║";

            Console.WriteLine(s, header0, header1);
            Console.Write("╠");
            for (int i = 0; i < width0; i++) Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < width1; i++) Console.Write("═");
            Console.WriteLine("╣");
        }

        // Метод для вывода низа таблицы
        public void TabDown()
        {
            Console.Write("╚");
            for (int i = 0; i < width0; i++) Console.Write("═");
            Console.Write("╩");
            for (int i = 0; i < width1; i++) Console.Write("═");
            Console.WriteLine("╝");
        }

        // Метод для вывода строки таблицы
        public void TabLine(double x, double y)
        {
            string s = "║{0," + width0.ToString() + "}║{1," + width1.ToString() + ":f3}║";
            Console.WriteLine(s, x, y);
        }
    }
    class Function
    {
        // Закрытые поля для хранения y и b
        double a, b;

        // Свойства для доступа к параметрам Func0
        public double aP
        {
            set { a = value; }
            get { return a; }
        }
        public double bP
        {
            set { b = value; }
            get { return b; }
        }

        // Метод для ввода xn, xk, dx
        public static void vvod(out double xn, out double xk, out double h)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите начальное значение: ");
            xn = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите конечное значение: ");
            xk = Convert.ToDouble(Console.ReadLine());
            h = 0;
            bool f = true;
            while (f)
            {
                Console.Write("Введите шаг табулирования: ");
                h = Convert.ToDouble(Console.ReadLine());
                if (h > 0) f = false;
                else
                    Console.WriteLine("Шаг отрицательный или нулевой, повторите попытку!");
            }
            if (h > xk - xn)
            {
                Console.WriteLine("Шаг слишком большой!");
                return;
            }
        }

        // Метод для вычисления значения функции
        public double func_b(double x)
        {
            if (Math.Pow(Math.Abs(x) + Math.Abs(a), 0.33) == 0)
            {
                Console.WriteLine("Деление на ноль!");
            }
            return Math.Pow(Math.Log(Math.Abs(b)), 2) / Math.Pow(Math.Abs(x) + Math.Abs(a), 0.33);
        }

        // Метод, результатом которого является строковое представление функции
        public string ToString()
        {
            string s;
            s = "f(x)=(Pow(Log(Abs" + b.ToString() + ", 2)) / " + "Pow(Abs(x)" + "Abs(" + a.ToString() + "), 1/3";
            return s;
        }

        // Метод для табулирования функции
        public void FunctionTab(double xn, double xk, double h)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Table tb2 = new Table("Табулирование функции №2 " + ToString(), "x", "f(x)", 5, 17);
            tb2.Hat();
            double x = xn;
            while ((xn < xk) ? (x <= xk + h / 2) : (x >= xk - h / 2))
            {
                tb2.TabLine(x, func_b(x));
                x = (xn < xk) ? (x + h) : (x - h);
            }
            tb2.TabDown();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double xxn, xxk, hx, x1, x2, x3;
            Function f1 = new Function();
            f1.aP = 4;
            f1.bP = 2;
            Function f2 = new Function();
            f2.aP = 3;
            f2.bP = 5;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Введите x1 = ");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите x2 = ");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите x3 = ");
            x3 = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Table tb1 = new Table("Табулирование фунции №2 ", "x", "f(x)", 5, 17);
            tb1.hdr = "Табулирование функции №1 " + f1.ToString();
            tb1.Hat();
            tb1.TabLine(x1, f1.func_b(x1));
            tb1.TabLine(x2, f1.func_b(x2));
            tb1.TabLine(x3, f1.func_b(x3));
            tb1.TabDown();
            tb1.hdr = "Табулирование функции №1 " + f2.ToString();
            tb1.Hat();
            tb1.TabLine(x1, f2.func_b(x1));
            tb1.TabLine(x2, f2.func_b(x2));
            tb1.TabLine(x3, f2.func_b(x3));
            tb1.TabDown();
            Function.vvod(out xxn, out xxk, out hx);
            f1.FunctionTab(xxn, xxk, hx);
            f2.FunctionTab(xxn, xxk, hx);
            Console.ReadKey();
        }
    }
}