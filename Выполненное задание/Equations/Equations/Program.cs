using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equations
{
    class Program
    {
        static void Main(string[] args)
        {
            Link:
            int n; // Количество уровнений 

            double[,] a = new double[3, 3]; // Матрица системы

            double[] b = new double[3]; // Вектор правых частей 

            double[] x = new double[3]; // Вектор решения            

            Console.Write("Введите трех линейное уравнение: n = ");

            n = Convert.ToInt32(Console.ReadLine());

            if (n > 3 || n <= 2)
            {

                Console.WriteLine("Ошибка в размерности системы (n=3)");
                Console.WriteLine("1.Запустить програаму заново ? 2.Закрывть программу");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        goto Link;
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
                Convert.ToInt32(Console.ReadLine());

                return;

            }

            for (int i = 0; i < n; i++)

                for (int j = 0; j < n; j++)

                {                                      
                    if (i == 1 && j == 2)
                    {
                        continue;        
                    }
                    Console.Write("A{0}{1} -> ", i, j);

                    a[i, j] = Convert.ToDouble(Console.ReadLine());
                }

            for (int i = 0; i < n; i++)
            {
                Console.Write("b{0} -> ", i);

                b[i] = Convert.ToDouble(Console.ReadLine());
            }

            if (SLAU_kramer(n, a, b, x) == 1)
            {
                Console.WriteLine("Система не имеет решение");
                Console.WriteLine("1.Запустить програаму заново ? 2.Закрывть программу");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        goto Link;
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
                Convert.ToInt32(Console.ReadLine());
                return;
            }
            else
            {
                for (int i = 0; i < n; i++)

                    Console.WriteLine("x" + i + " = " + x[i]);

                Console.ReadLine();
            }
        }

        private
        static double det(int n, double[,] B)
        {
            if (n == 2)

                return B[0, 0] * B[1, 1] - B[0, 1] * B[1, 0];

            return B[0, 0] * (B[1, 1] * B[2, 2] - B[1, 2] * B[2, 1]) - B[0, 1] * (B[1, 0] * B[2, 2] - B[1, 2] * B[2, 0]) +

            B[0, 2] * (B[1, 0] * B[2, 1] - B[1, 1] * B[2, 0]);

        }
        

        static void equal(int n, double[,] A, double[,] B)

        {

            for (int i = 0; i < n; i++)

                for (int j = 0; j < n; j++)

                    A[i, j] = B[i, j];

        }

        static void change(int n, int N, double[,] A, double[] b)

        {

            for (int i = 0; i < n; i++)

                A[i, N] = b[i];

        }

        public

        static int SLAU_kramer(int n, double[,] A, double[] b, double[] x)

        {

            double[,] An = new double[3, 3];

            double det1 = det(n, A);

            if (det1 == 0) return 1;

            for (int i = 0; i < n; i++)

            {

                equal(n, An, A);

                change(n, i, An, b);

                x[i] = det(n, An) / det1;

            }

            return 0;

        }

    }

}
