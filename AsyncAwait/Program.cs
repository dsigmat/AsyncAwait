using System;
using System.Threading;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DoWork));
            thread.Start();

            Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork));
            thread2.Start(int.MaxValue);

            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;

                if (j % 10000 == 0)
                {
                    Console.WriteLine("Main DoWork 1");
                }
            }

            Console.ReadLine();
        }

        static void DoWork()
        {
            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;

                if (j%10000 == 0)
                {
                    Console.WriteLine("Potok DoWork 2");
                }
            }
        }

        static void DoWork(object max)
        {
            int j = 0;
            for (int i = 0; i < (int)max; i++)
            {
                j++;

                if (j % 10000 == 0)
                {
                    Console.WriteLine("Potok DoWork 3");
                }
            }
        }
    }
}
