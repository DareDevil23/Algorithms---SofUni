namespace _01.Sorting
{
    public class QuickSort
    {

        public static void Sort(int[] array)
        {
            SortPartition(array, 0, array.Length);           
        }

        private static void SortPartition(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivotIndex = start;

            for (int index = pivotIndex + 1; index < array.Length; index++)
            {
                if (array[pivotIndex] > array[index])
                {
                    Swap(array, index, pivotIndex);
                    pivotIndex = index;
                }
            }

            SortPartition(array, start, pivotIndex);
            SortPartition(array, pivotIndex + 1, end);
        }

        private static void Swap(int[] array, int pivotIndex, int index)
        {
            int temp = array[pivotIndex];

            array[pivotIndex] = array[index];
            array[index] = temp;
        }
    }
}
