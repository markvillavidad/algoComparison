using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] dataSize = { 1, 2, 10,20, 1000000 };

            foreach (int size in dataSize)
            {
                //------------------------------------------------------
                int[] unOrderedList = Utils.generateNumbers2(size);
                int[] ListSerial = unOrderedList.ToArray();
                int[] ListParallel = unOrderedList.ToArray();


                Console.WriteLine("\n\n Quick Sort: ");
                Console.WriteLine("Data Size ={0}: ", size);

                Console.WriteLine("\nOriginal array elements:\n");
                for (int i = 0; i < unOrderedList.Length; i++)
                {
                    Console.Write(unOrderedList[i] + " ");
                }
                // Console.WriteLine("\n----------------------------------------------\n");
                Stopwatch sw = new Stopwatch();
                sw.Start();
                //QuickSort.Quick_Sort(ListSerial, 0, unOrderedList.Length - 1);
                BubbleSort.SortSerial(ListSerial);
                sw.Stop();

                Console.WriteLine("\nSerial Time={0}", sw.Elapsed.TotalMilliseconds);
                // Console.WriteLine("\n----------------------------------------------\n");


                Console.WriteLine("\n Ordered array elements:\n");
                foreach (var item in ListSerial)
                {
                    Console.Write(" " + item);
                }

                //   Console.WriteLine("\n----------------------------------------------\n");


                //    Console.WriteLine("\nOriginal array elements:\n");
                //    for (int i = 0; i < unOrderedList.Length; i++)
                //    {
                //       Console.Write(unOrderedList[i] + " ");
                //   }

                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                QuickSort.QuicksortParallel(ListParallel, 0, unOrderedList.Length - 1);
                sw.Stop();
                Console.WriteLine("\nParallel Time={0}", sw1.Elapsed.TotalMilliseconds);
            //    Console.WriteLine("\n----------------------------------------------\n");


            //    Console.WriteLine("\n Ordered array elements:\n");
              //  foreach (var item in ListParallel)
              //  {
              //      Console.Write(" " + item);
             //   }
             //   Console.WriteLine("\n----------------------------------------------\n");



            }
     

        }

       




    }
}