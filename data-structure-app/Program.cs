namespace data_structure_app
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string parameter = args.FirstOrDefault(f => f.ToLower().StartsWith("run"));
            string[] dataStructireListParameter = null;
            var dataStructureFactory = new DataStructureFactory();            

            if (parameter != null)
            {
                dataStructireListParameter = parameter.Substring(4).Split(",");
            }

            if (dataStructireListParameter is null || dataStructireListParameter.Any(w => "binarytree".Contains(w.ToLower())))
                dataStructureFactory.Create<BinaryTree>();

            if (dataStructireListParameter is null || dataStructireListParameter.Any(w => "hashtable".Contains(w.ToLower())))
                dataStructureFactory.Create<HashTable>();

            if (dataStructireListParameter is null || dataStructireListParameter.Any(w => "quicksort".Contains(w.ToLower())))
                dataStructureFactory.Create<QuickSort>();

            if (dataStructireListParameter is null || dataStructireListParameter.Any(w => "heapsort".Contains(w.ToLower())))
                dataStructureFactory.Create<HeapSort>();

            if (dataStructireListParameter is null || dataStructireListParameter.Any(w => "linkedlist".Contains(w.ToLower())))
                dataStructureFactory.Create<LinkedList>();

            dataStructureFactory.Run();

        }
    }
}

