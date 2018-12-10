using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace NameSort
{
    class name
    {
        public name(string fname, string lname)
        {
            this.firstName = fname; this.lastName = lname;
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<name> Names = new List<name>();
            // populate the list of names from a file
            using (StreamReader sr = new StreamReader("names.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] s = sr.ReadLine().Split(' ');
                    Names.Add(new name(s[0], s[1]));
                }
            }
            Console.WriteLine("Sorting...");
            // time the sort.
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<name> sortedNames = Names.OrderBy(s => s.lastName).ThenBy(s => s.firstName).ToList();
            stopwatch.Stop();
            Console.WriteLine("Sorted List", sortedNames);
            //foreach (var el in sortednames)
            //{
            //    console.writeline(el.lastname + ", " + el.firstname);
            //}
            Console.WriteLine("Default sorting code took {0} milliseconds to execute", stopwatch.ElapsedMilliseconds);

            List<String> allNames = new List<String>();
            foreach (var el in Names) {
                allNames.Add(el.lastName + " " + el.firstName);
            }

            Stopwatch stopwatch1 = Stopwatch.StartNew();
            Algo1.QuickSort.Quicksort(allNames, 0, allNames.Count-1);
            stopwatch1.Stop();

            Console.WriteLine("Quick Sort code took {0} milliseconds to execute", stopwatch1.ElapsedMilliseconds);


            List<String> allNames2 = new List<String>();
            foreach (var el in Names)
            {
                allNames2.Add(el.lastName + " " + el.firstName);
            }
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            Algo1.QuickSort.QuicksortParallel(allNames, 0, allNames.Count - 1);
            stopwatch1.Stop();

            Console.WriteLine("Quick Sort Parallel code took {0} milliseconds to execute", stopwatch2.ElapsedMilliseconds);





            Console.WriteLine("Press Return to exit");
            Console.ReadLine();
        }
    }
}