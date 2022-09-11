namespace data_structure_app
{
    public class QuickSort: IDataStructure
    {
        public int[] ChangeValue(int[] data, int left, int right)
        {
            int swap = data[right];
            data[right] = data[left];
            data[left] = swap;

            return data;
        }

        public int Partition(int[] data, int left, int right)
        {
            int pivot = data[left];

            while (true)
            {
                while (data[left] < pivot)
                    left++;

                while (data[right] > pivot)
                    right--;

                if (left < right)
                    ChangeValue(data, left, right);
                else
                    return right;

            }
        }

        public int[] ExecuteSortQuick(int[] data, int left, int right)
        {

            if (left < right)
            {
                int pivot = Partition(data, left, right);

                if (pivot > 1)
                    ExecuteSortQuick(data, left, (pivot - 1));

                if ((pivot + 1) < right)
                    ExecuteSortQuick(data, pivot + 1, right);
            }

            return data;
        }

        [ExcludeFromCodeCoverage]
        public void Run()
        {
            Console.WriteLine("\n");
            Console.WriteLine(" ******************** Start Quick Sort ******************** ");

            Console.Write("\n\nEnter number of elements: ");

            int max = Convert.ToInt32(Console.ReadLine());
            int index;

            int[] numbers = new int[max];

            for (index = 0; index < max; index++)
            {
                Console.Write("\nEnter [" + (index + 1).ToString() + "] element: ");
                numbers[index] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Input int array  : ");
            for (index = 0; index < max; index++)
                Console.Write(numbers[index] + " ");

            var result = ExecuteSortQuick(numbers, 0, (max - 1));

            Console.Write("\nQuickSort By Recursive Method: ");
            for (index = 0; index < max; index++)
                Console.Write(result[index] + " ");

            Console.WriteLine("\n ******************** End Quick Sort ******************** ");
        }
    }
}
