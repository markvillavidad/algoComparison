using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {

            //       //------------------------------------------------------
            //        //Generate Random Numbers
            //        List<int> unSorted = generateNumbers(50000);
            //
            //        Console.WriteLine("Original array elements:");
            //        foreach (int i in unSorted){
            //            Console.Write(i + " ");
            //        }

            //        //------------------------------------------------------

            //        List<int> sorted;
            //        sorted = sequentialMergeSort(unSorted);

            //      Console.WriteLine("\n\nSorted array elements: ");
            //        foreach (int i in sorted)
            //        {
            //            Console.Write(i + " ");
            //       }

            int[] dataSize = { 1, 2, 10, 100, 1000, 10000, 50000 };

            foreach (int size in dataSize)
            {
                //------------------------------------------------------
                int[] unOrderedList = generateNumbers2(size);
                int[] ListSerial = unOrderedList.ToArray();
                int[] ListParallel = unOrderedList.ToArray();

                Console.WriteLine("Original array elements:");
             //   for (int i = 0; i < unOrderedList.Length; i++)
            //    {
            //        Console.Write(unOrderedList[i] + " ");
            //    }

                //------------------------------------------------------
                Stopwatch sw = new Stopwatch();

                sw.Start();
                Quick_Sort(ListSerial, 0, unOrderedList.Length - 1);
                sw.Stop();
                Console.WriteLine("\n\n Quick Sort: ");
                Console.WriteLine("Data Size ={0}: ", size);
                Console.WriteLine("Serial Time={0}", sw.Elapsed.TotalMilliseconds);
                //  foreach (var item in ListSerial)
                //  {
                //       Console.Write(" " + item);
                //  }
                sw.Start();
                QuicksortParallel(ListParallel, 0, unOrderedList.Length - 1);
                sw.Stop();
                Console.WriteLine("Parallel Time={0}", sw.Elapsed.TotalMilliseconds);


                //  foreach (var item in ListParallel)
                //  {
                //      Console.Write(" " + item);
                //  }
                Console.WriteLine("----------------------------------------------");



            }
     



        }

        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }

        private static void QuicksortParallel(int[] arr, int left, int right)
        {
            // If the list to sort contains one or less element, the list is already sorted.
            if (right <= left) return;
   
           // Partitioning our list and getting a pivot.
            var pivot = Partition(arr, left, right);

           // Sorting the left and right of the pivot in parallel

                Parallel.Invoke(
                    () => QuicksortParallel(arr, left, pivot - 1),
                   () => QuicksortParallel(arr, pivot + 1, right)); 
        }



        public static List<int> generateNumbers(int size)
        {

            //int[] unOrderedList = new int[size];
            List<int> unOrderedList = new List<int>();

            for (int i = 0; i < size; i++)
            {
                Random rnd = new Random();
                unOrderedList.Add(rnd.Next(-100000, 1000000));
            }
            return unOrderedList;
        }

        public static int [] generateNumbers2(int size)
        {

            int[] unOrderedList = new int[size];
            //List<int> unOrderedList = new List<int>();

            for (int i = 0; i < size; i++)
            {
                Random rnd = new Random();
                //unOrderedList.Add(rnd.Next(-100000, 1000000));
                unOrderedList[i] = rnd.Next(-100000, 1000000);
            }
            return unOrderedList;
        }




    }
}