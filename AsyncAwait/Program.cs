using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        public static object locker = new object();
        static void Main(string[] args)
        {
            #region thread
            //Thread thread = new Thread(new ThreadStart(DoWork));
            //thread.Start();

            //Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork));
            //thread2.Start(int.MaxValue);

            //int j = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    j++;

            //    if (j % 10000 == 0)
            //    {
            //        Console.WriteLine("Main DoWork 1");
            //    }
            //}
            #endregion

            #region async/await
            //Console.WriteLine("Begin main");

            //DoWorkAsync(1000);

            //Console.WriteLine("Continue Main");

            //for (int i = 0; i < 10; i++)
            //{
            //        Console.WriteLine("Main");
            //}
            //Console.WriteLine("End Main");
            #endregion

            var result = SaveFileAsync("test.txt");
            var input = Console.ReadLine();
            Console.WriteLine(result.Result);
        }

        static async Task<bool> SaveFileAsync(string path)
        {
            var result = await Task.Run(() => SaveFile(path));
            return result;
        }

        static bool SaveFile(string path)
        {
            lock (locker)
            {
                var rnd = new Random();
                var txt = "";
                for (int i = 0; i < 100; i++)
                {
                    txt += rnd.Next();
                }
            }
            
            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine();
            }
            return true;
        }

        static async Task DoWorkAsync(int max)
        {
            Console.WriteLine("Begin Async");
            await Task.Run(() => DoWork(max));
            Console.WriteLine("End Async");
        }

        static void DoWork(int max)
        {
            for (int i = 0; i < max; i++)
            {
                    Console.WriteLine("Potok DoWork 2");
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
