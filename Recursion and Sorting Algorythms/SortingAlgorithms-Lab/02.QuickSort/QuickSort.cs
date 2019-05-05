namespace _02.QuickSort
{
    using System;

    public class QuickSort
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start >= end)
            {
                return;
            }

            int pivotIndex = Partition(array, start, end);

            Sort(array, start, pivotIndex - 1);
            Sort(array, pivotIndex + 1, end);
        }

        private static int Partition<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start >= end)
            {
                return start;
            }

            int i = start;
            int j = end + 1;

            while (true)
            {
                while (Less(array[++i], array[start]))
                {
                    if (i == end)
                        break;
                }

                while (Less(array[start], array[--j]))
                {
                    if (j == start)
                        break;
                }

                if (i >= j)
                    break;

                Swap(array, i, j);
            }

            Swap(array, start, j);

            return j;
        }

        private static void Swap<T>(T[] array, int firstElementIndex, int secondElementIndex) where T : IComparable<T>
        {
            T temp = array[firstElementIndex];

            array[firstElementIndex] = array[secondElementIndex];
            array[secondElementIndex] = temp;
        }

        private static bool Less<T>(T first, T second) where T : IComparable<T>
        {
            return first.CompareTo(second) < 0;
        }

    }
}
