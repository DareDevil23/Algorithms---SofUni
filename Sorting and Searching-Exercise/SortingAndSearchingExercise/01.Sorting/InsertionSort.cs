namespace _01.Sorting
{
    using System;

    public class InsertionSort
    {
        public static void Sort(int[] array)
        {           
            int pivotIndex = 0, index = 1;

            while(index < array.Length)
            {
                int currentElement = array[index];

                if (currentElement < array[pivotIndex])
                {
                    Insertion(array, pivotIndex, index);
                }

                pivotIndex++;
                index++;
            } 
        }

        private static void Insertion(int[] array, int pivotIndex, int elementIndex)
        {
            int currentElement = array[elementIndex];

            int j = pivotIndex;

            while(j >= 0 && currentElement <= array[j])
            {
                j--;       
            }

            ShiftRight(array, ++j, elementIndex - 1);
            array[j] = currentElement;
        }

        private static void ShiftRight(int[] array, int start, int end)
        {
            int length = end - start + 1;
            int[] temp = new int[length];
            Array.Copy(array, start, temp, 0, length);

            int j = 0;
            for (int i = start + 1; i <= end + 1; i++)
            {
                array[i] = temp[j++];
            }
        }
    }
}
