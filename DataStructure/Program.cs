using System;

namespace DataStructure
{
    class Program
    {
        static bool isPrint;
        static SortAlgorithm sortAlgorithm;

        static void Main(string[] args)
        {
            isPrint = true;
            sortAlgorithm = new SortAlgorithm(10);

            ExecuteCommand(SortType.None);
            //ExecuteCommand(SortType.BubbleSort);
            //ExecuteCommand(SortType.InsertionSort);
            //ExecuteCommand(SortType.SelectionSort);
            //ExecuteCommand(SortType.MergeSort);
            ExecuteCommand(SortType.QuickSort);
            Console.ReadKey();
        }

        private static void ExecuteCommand(SortType sortType)
        {
            Console.WriteLine(sortType.ToString());
            sortAlgorithm.Reset();
            Console.WriteLine(sortAlgorithm.Sort(sortType));
            if (isPrint) sortAlgorithm.Print();
            Console.WriteLine("--------------------------------------");
        }
    }
}
