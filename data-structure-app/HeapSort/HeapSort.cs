namespace data_structure_app
{
    public class HeapSort : IDataStructure
    {
        public int[] ChangeValue(int[] data, int index, int largest)
        {
            int swap = data[index];
            data[index] = data[largest];
            data[largest] = swap;

            return data;
        }

        public int[] ExecuteHeapSort(int[] data)
        {
            int length = data.Length;
            int index;

            for (index = length / 2 - 1; index >= 0; index--)
            {
                Heapify(data, length, index);
            }

            for (index = length - 1; index >= 0; index--)
            {
                ChangeValue(data, 0, index);
                Heapify(data, index, 0);
            }

            return data;
        }

        public int[] Heapify(int[] data, int length, int index)
        {
            int largest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < length && data[left] > data[largest])
                largest = left;

            if (right < length && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                ChangeValue(data, index, largest);
                Heapify(data, length, largest);
            }

            return data;
        }

        [ExcludeFromCodeCoverage]
        public void Run()
        {
            Console.WriteLine("\n");
            Console.WriteLine(" ******************** Start Heap Sort ******************** ");

            Console.Write("\nEnter number of elements: ");

            int max = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[max];
            int index;

            for (index = 0; index < max; index++)
            {
                Console.Write("\nEnter [" + (index + 1).ToString() + "] element: ");
                numbers[index] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Start Heap Sort");
            Console.Write("Initial array is: ");

            for (index = 0; index < numbers.Length; index++)
                Console.Write(numbers[index] + " ");

            Console.Write("\nSorted Array is: ");
            var result = ExecuteHeapSort(numbers);

            for (index = 0; index < result.Length; index++)
                Console.Write(numbers[index] + " ");

            Console.WriteLine("\n\n ******************** End Heap Sort ******************** ");
        }
    }
}
