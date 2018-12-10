﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algo1
{
    class QuickSort
    {


        private static void Swap<T>(IList<T> arr, int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }


        public static void Quicksort<T>(IList<T> arr, int left, int right) where T : IComparable<T>
        {
            // If the list contains one or less element: no need to sort!
            if (right <= left) return;

            // Partitioning our list
            var pivot = Partition(arr, left, right);

            // Sorting the left of the pivot
            Quicksort(arr, left, pivot - 1);
            // Sorting the right of the pivot
            Quicksort(arr, pivot + 1, right);
        }


        private static int Partition<T>(IList<T> arr, int low, int high)
            where T : IComparable<T>
        {
            /*
                * Defining the pivot position, here the middle element is used but the choice of a pivot
                * is a rather complicated issue. Choosing the left element brings us to a worst-case performance,
                * which is quite a common case, that's why it's not used here.
                */
            var pivotPos = (high + low) / 2;
            var pivot = arr[pivotPos];
            // Putting the pivot on the left of the partition (lowest index) to simplify the loop
            Swap(arr, low, pivotPos);

            /** The pivot remains on the lowest index until the end of the loop
                * The left variable is here to keep track of the number of values
                * that were compared as "less than" the pivot.
                */
            var left = low;
            for (var i = low + 1; i <= high; i++)
            {
                // If the value is greater than the pivot value we continue to the next index.
                if (arr[i].CompareTo(pivot) >= 0) continue;

                // If the value is less than the pivot, we increment our left counter (one more element below the pivot)
                left++;
                // and finally we swap our element on our left index.
                Swap(arr, i, left);
            }

            // The pivot is still on the lowest index, we need to put it back after all values found to be "less than" the pivot.
            Swap(arr, low, left);

            // We return the new index of our pivot
            return left;
        }


        public static void QuicksortParallel<T>(IList<T> arr, int left, int right)
            where T : IComparable<T>
        {
            // Defining a minimum length to use parallelism, over which using parallelism
            // got better performance than the sequential version.
            const int threshold = 8;

            // If the list to sort contains one or less element, the list is already sorted.
            if (right <= left) return;

            // If the size of the list is under the threshold, sequential version is used.
            if (right - left < threshold)
                Quicksort(arr, left, right);

            else
            {
                // Partitioning our list and getting a pivot.
                var pivot = Partition(arr, left, right);

                // Sorting the left and right of the pivot in parallel
                Parallel.Invoke(
                    () => QuicksortParallel(arr, left, pivot - 1),
                    () => QuicksortParallel(arr, pivot + 1, right));
            }
        }
    }


}
