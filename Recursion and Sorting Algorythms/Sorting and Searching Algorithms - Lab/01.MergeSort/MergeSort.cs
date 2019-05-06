namespace _01.MergeSort
{
    using System;

    public class MergeSort<T> where T : IComparable
    {
        public static T[] temp;

        public static void Sort(T[] array)
        {
            temp = new T[array.Length];
            Slice(array, 0, array.Length - 1);
        }

        private static void Slice(T[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid =  start + (end - start) / 2;

            Slice(array, start, mid);
            Slice(array, mid + 1, end);

            Merge(array, start, mid, end);
        }

        private static void Merge(T[] array, int start, int mid, int end)
        {
            if (IsLess(array[mid], array[mid + 1]))
            {
                return;
            }

            for (int index = start; index <= end; index++)
            {
                temp[index] = array[index];
            }

            int i = start; //index for the left array
            int j = mid + 1; // index for the right array

            for (int index = start; index <= end; index++)
            {
                if (i > mid) // left array index is outside
                {
                    array[index] = temp[j++];
                }
                else if(j > end) //right array index is outside
                {
                    array[index] = temp[i++];
                }
                else if(IsLess(temp[i], temp[j])) // takes the lower element from left or right array
                {
                    array[index] = temp[i++];
                }
                else
                {
                    array[index] = temp[j++];
                }
            }
        }

        private static bool IsLess(T left, T right)
        {
            return left.CompareTo(right) < 0;
        }

    }
}
