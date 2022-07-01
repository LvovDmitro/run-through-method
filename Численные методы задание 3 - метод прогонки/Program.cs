using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Численные_методы_задание_3___метод_прогонки
{
    class Program
    {
        public static double U(double x)
        {
            double rez = ((Math.Pow(x, 2)) * (Math.Pow(1 - x, 2)));
            return rez;
        }
        public static double P(double x)
        {
            double rez = 1 + x;
            return rez;
        }
        public static double G(double x)
        {
            double rez = 1 + x;
            return rez;
        }
        public static double f(double x)
        {
            double rez = (Math.Pow(x, 5)) -(Math.Pow(x, 4)) -17*(Math.Pow(x,3))+ 7* (Math.Pow(x, 2))+8*x - 2;
            return rez;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n");
            int n = int.Parse(Console.ReadLine());
            int a = 0, b = 1;
            double h = (double)(b - a) / n;
            double[] ai = new double[n + 1];
            double[] gi = new double[n + 1];
            double[] fi = new double[n + 1];
            double[] al = new double[n + 1];
            double[] bet = new double[n + 1];
            double[] arrA = new double[n + 1];
            double[] arrB = new double[n + 1];
            double[] arrC = new double[n + 1];
            double[] arrY = new double[n + 1];

            al[1] = bet[1] = 0;
            arrY[0] = arrY[n] = 0;

            for (int i = 0; i < n + 1; i++)
            {
                ai[i] = P(i * h);
                gi[i] = G(i * h);
                fi[i] = f(i * h) * Math.Pow(h, 2);
            }

            for (int i = 1; i < n; i++)
            {
                arrA[i] = -ai[i];
                arrB[i] = -(ai[i] + ai[i + 1] + h * h * gi[i]);
                arrC[i] = -ai[i + 1];
            }

            for (int i = 1; i < n; i++)
            {
                al[i + 1] = arrC[i] / (arrB[i] - arrA[i] * al[i]);
                bet[i + 1] = (arrA[i] * bet[i] - fi[i]) / (arrB[i] - arrA[i] * al[i]);
            }
            for (int i = n - 1; i > 0; i--)
            {
                arrY[i] = al[i + 1] * arrY[i + 1] + bet[i + 1];
            }
            Console.WriteLine("i*h" + "\t\t" + "U(ih)" + "\t\t" + "Yi" + "\t\t" + "|U(ih)-Yi|");
            Console.WriteLine("");
            for (int i = 0; i < n + 1; i++)
            {
                Console.WriteLine(Math.Round(i * h,2) + "\t\t" + Math.Round(U(i * h), 5) + "\t\t" + Math.Round(arrY[i], 5) + "\t\t" + Math.Abs(Math.Round(U(i * h),5) - Math.Round(arrY[i],5)));
            }
            Console.ReadKey();
        }
    }
}
