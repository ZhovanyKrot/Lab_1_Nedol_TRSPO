using System;
using System.Threading;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Lab1();
            Thread.Sleep(5000);
            Lab2();

            static void Lab2()
            {
                Random rnd = new Random();
                int m = 2;
                int n = 2;
                int k = 2;

                for (int i = 1; i < 5; i++)
                {
                    Thread myThread = new(Masiv_Actions);
                    Console.WriteLine($"Потiк: {i}");
                    myThread.Start();
                    Thread.Sleep(2000);
                }

                void Masiv_Actions()
                {
                    int[,] mas1 = new int[m, n];
                    int[,] mas2 = new int[n, k];
                    int[,] mas3 = new int[m, k];

                    mas1 = Create_Masiv(m, n);
                    mas2 = Create_Masiv(n, k);

                    mas3 = Multiple_Masiv(mas1, mas2);

                    Console.WriteLine("Masiv 1");
                    Print_Masiv(mas1);
                    Console.WriteLine("Masiv 2");
                    Print_Masiv(mas2);
                    Console.WriteLine("Masiv 3");
                    Print_Masiv(mas3);
                }
                int[,] Create_Masiv(int d, int f)
                {
                    int[,] mas = new int[d, f];

                    for (int i = 0; i < d; i++)
                    {
                        for (int j = 0; j < f; j++)
                        {
                            mas[i, j] = rnd.Next(0, 10);
                        }
                    }
                    return mas;
                }
                int[,] Multiple_Masiv(int[,] arr1, int[,] arr2)
                {
                    int[,] arr3 = new int[m, k];

                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            for (int f = 0; f < n; f++)
                            {
                                arr3[i, j] += arr1[i, f] * arr2[f, j];
                            }
                        }
                    }
                    return arr3;
                }
                void Print_Masiv(int[,] arr)
                {
                    for (int i = 0; i < n; i++, Console.WriteLine())
                    {
                        for (int j = 0; j < k; j++)
                        {
                            Console.Write(arr[i, j] + " ");
                        }
                    }
                }
            }

            static void Lab1()
            {
                int x = 1;
                for (int i = 1; i < 5; i++)
                {
                    Thread myThread = new(Print);
                    myThread.Name = $"Поток {i}";
                    myThread.Start();
                }

                void Print()
                {
                    for (int i = 1; i < 5; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                        x++;
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
}