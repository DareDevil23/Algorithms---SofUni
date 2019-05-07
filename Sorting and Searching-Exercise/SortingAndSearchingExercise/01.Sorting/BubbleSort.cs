namespace _01.Sorting
{
    public class BubbleSort
    {
        public static void Sort(int[] array)
        {           
            while (true)
            {
                bool hasSwap = false;

                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < array[i-1])
                    {
                        Swap(array, i);
                        hasSwap = true;
                    }
                }

                if (!hasSwap)
                {
                    break;
                }
            }
        }

        private static void Swap(int[] array, int index)
        {
            int temp = array[index - 1];

            array[index - 1] = array[index];
            array[index] = temp;
        }
    }
}
