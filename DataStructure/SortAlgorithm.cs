using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace DataStructure
{
    enum SortType
    {
        None,
        BubbleSort,
        InsertionSort,
        MergeSort,
        QuickSort,
        SelectionSort,

    }


    class SortAlgorithm
    {
        List<int> container = new List<int>();
        List<int> containerBackUp = new List<int>();
        Stopwatch stopWatch = new Stopwatch();

        #region # 
        public SortAlgorithm()
        {
            Initialize();
        }
        public SortAlgorithm(int sizeOfContainer)
        {
            Initialize(sizeOfContainer);
        }
        private void Initialize(int sizeOfContainer = 0)
        {
            Random _rand = new Random();
            for (int counterComplete = 0; counterComplete < sizeOfContainer; counterComplete++)
            {
                container.Add(_rand.Next(0, 100));
            }
            containerBackUp = new List<int>(container);
        }
        public void Reset()
        {
            container = new List<int>(containerBackUp);
        }
        public string Sort(SortType sortType)
        {
            stopWatch.Restart();

            if (sortType == SortType.SelectionSort) SelectionSort();
            if (sortType == SortType.InsertionSort) InsertionSort();
            if (sortType == SortType.BubbleSort) InsertionSort();
            if (sortType == SortType.MergeSort) MergeSort(0, container.Count - 1);
            if (sortType == SortType.QuickSort) QuickSort(0, container.Count - 1);

            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}.{4}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds, stopWatch.ElapsedTicks);
        }
        public void Print()
        {

            Console.Write("   ");
            for (int counterComplete = 0; counterComplete < container.Count; counterComplete++)
            {
                if (container[counterComplete] < 10) Console.Write(" "); Console.Write(container[counterComplete]);
                if (counterComplete + 1 < container.Count) Console.Write(" | ");
            }
            Console.WriteLine();
        }
        #endregion
        #region Sort Algorithm

        private void BubbleSort()
        {
            int containerLength = container.Count;
            int counterComplete, counterSegement, tempKey;

            for (counterComplete = 0; counterComplete < containerLength - 1; counterComplete++)
                for (counterSegement = 0; counterSegement < containerLength - counterComplete - 1; counterSegement++)
                    if (container[counterSegement] > container[counterSegement + 1])
                    {
                        tempKey = container[counterSegement];
                        container[counterSegement] = container[counterSegement + 1];
                        container[counterSegement + 1] = tempKey;
                    }
        }

        private void InsertionSort()
        {
            int containerLength = container.Count;
            int counterComplete, counterSegement, tempKey;

            for (counterComplete = 1; counterComplete < containerLength; counterComplete++)
            {
                tempKey = container[counterComplete];
                counterSegement = counterComplete - 1;

                while (counterSegement >= 0 && container[counterSegement] > tempKey)
                {
                    container[counterSegement + 1] = container[counterSegement];
                    counterSegement = counterSegement - 1;
                }
                container[counterSegement + 1] = tempKey;
            }
        }

        private void SelectionSort()
        {
            int containerLength = container.Count;
            int counterComplete, counterSegement, tempKey;

            for (counterComplete = 0; counterComplete < containerLength - 1; counterComplete++)
            {
                int minimumIndex = counterComplete;

                for (counterSegement = counterComplete + 1; counterSegement < containerLength; counterSegement++)
                    if (container[counterSegement] < container[minimumIndex])
                        minimumIndex = counterSegement;

                tempKey = container[minimumIndex];
                container[minimumIndex] = container[counterComplete];
                container[counterComplete] = tempKey;
            }
        }

        void MergeContainer(int leftIndex, int middleIndex, int rightIndex)
        {
            int counterComplete, counterLeft, counterRight;

            int lengthFirst = middleIndex - leftIndex + 1;
            int lengthSecond = rightIndex - middleIndex;

            List<int> containerLeft = new List<int>();
            List<int> containerRight = new List<int>();

            for (counterLeft = 0; counterLeft < lengthFirst; counterLeft++)
            { containerLeft.Add(container[leftIndex + counterLeft]); }

            for (counterRight = 0; counterRight < lengthSecond; counterRight++)
            { containerRight.Add(container[middleIndex + 1 + counterRight]); }

            counterLeft = 0;
            counterRight = 0;
            counterComplete = leftIndex;

            while (counterLeft < lengthFirst && counterRight < lengthSecond)
            {
                if (containerLeft[counterLeft] <= containerRight[counterRight])
                {
                    container[counterComplete] = containerLeft[counterLeft];
                    counterLeft++;
                }
                else
                {
                    container[counterComplete] = containerRight[counterRight];
                    counterRight++;
                }
                counterComplete++;
            }

            while (counterLeft < lengthFirst)
            {
                container[counterComplete] = containerLeft[counterLeft];
                counterLeft++;
                counterComplete++;
            }

            while (counterRight < lengthSecond)
            {
                container[counterComplete] = containerRight[counterRight];
                counterRight++;
                counterComplete++;
            }
        }
        
        void MergeSort(int leftIndex, int rightIndex)
        {
            int middleIndex;
            if (leftIndex < rightIndex)
            {
                middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
                MergeSort(leftIndex, middleIndex);
                MergeSort(middleIndex + 1, rightIndex);

                MergeContainer(leftIndex, middleIndex, rightIndex);
            }
        }

        int Partition(int leftIndex, int rightIndex)
        {
            int pivotValue = container[rightIndex];
            int tempKey;

            int firstPointer = leftIndex - 1;
            int secondPointer;
            
            for (secondPointer = leftIndex; secondPointer < rightIndex; secondPointer++)
            {
                if (container[secondPointer] < pivotValue)
                {
                    firstPointer++;

                    tempKey = container[firstPointer];
                    container[firstPointer] = container[secondPointer];
                    container[secondPointer] = tempKey;
                }
            }
            
            int tempKey1 = container[firstPointer + 1];
            container[firstPointer + 1] = container[rightIndex];
            container[rightIndex] = tempKey1;

            return firstPointer + 1;
        }

        
        void QuickSort(int leftIndex, int rightIndex)
        {
            int middleIndex;
            if (leftIndex < rightIndex)
            {
                middleIndex = Partition(leftIndex, rightIndex);
                QuickSort(leftIndex, middleIndex - 1);
                QuickSort(middleIndex + 1, rightIndex);
            }
        }


        #endregion


    }
}
