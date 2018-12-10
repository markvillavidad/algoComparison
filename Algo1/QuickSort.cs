using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algo1
{
    class QuickSort
    {
        public static void Quick_Sort(int[] arr, int left, int right)
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

        public static void QuicksortParallel(int[] arr, int left, int right)
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


    }
}
