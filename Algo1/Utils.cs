using System;
using System.Collections.Generic;
using System.Text;

namespace Algo1
{
    class Utils
    {
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

        public static int[] generateNumbers2(int size)
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
