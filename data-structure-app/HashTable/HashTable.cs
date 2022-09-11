namespace data_structure_app
{
    public class HashTable : IDataStructure
    {
        public string SearchByKey(Hashtable hashtable, object key)
        {
            if (!hashtable.ContainsKey(key))
                throw new ArgumentException($"Key {key}, not found");

            return $"- key: {key}, your value: {hashtable[key]}";
        }

        public void Remove(Hashtable hashtable, object key)
        {
            if (!hashtable.ContainsKey(key))
                throw new ArgumentException($"Key {key}, not found");

            hashtable.Remove(key);
        }

        public void Insert(Hashtable hashtable, object key, object value)
        {
            hashtable.Add(key, value);
        }

        public Hashtable List(Hashtable hashtables)
        {
            if (hashtables.Count <= 0)
                throw new ArgumentException("This hastables is empty");

            return hashtables;
        }

        [ExcludeFromCodeCoverage]
        public void Run()
        {
            Console.WriteLine("\n");
            Console.WriteLine(" ******************** Start Hash Table ******************** ");
            var hashtables = new Hashtable();
            bool isLooping = true;

            while (isLooping)
            {
                try
                {
                    Console.WriteLine("Select you Method ");
                    Console.WriteLine("\n1 - List \n2 - Insert \n3 - Remove \n4 - Search by key \n5 - Exit ");

                    var selectedMethod = (EnumHasTableMethods)Convert.ToInt32(Console.ReadLine());

                    switch (selectedMethod)
                    {
                        case EnumHasTableMethods.List:
                            var result = List(hashtables);
                            foreach (DictionaryEntry item in result)
                            {
                                Console.WriteLine($"- key: {item.Key}, your value: {item.Value}");
                            }
                            break;

                        case EnumHasTableMethods.Insert:
                            Console.WriteLine("Insert your key");
                            object key = Console.ReadLine();
                            Console.WriteLine("Insert your value");
                            object value = Console.ReadLine();
                            Insert(hashtables, key, value);
                            Console.WriteLine("Successfully inserted");
                            break;

                        case EnumHasTableMethods.Remove:
                            Console.WriteLine("Insert your key to delete Them");
                            int keyToRemove = Convert.ToInt32(Console.ReadLine());
                            Remove(hashtables, keyToRemove);
                            Console.WriteLine(" Successfully deleted");
                            break;

                        case EnumHasTableMethods.SearchByKey:
                            Console.WriteLine("Insert your key to search");
                            string? searchKey = Console.ReadLine();
                            string resultSearch = SearchByKey(hashtables, searchKey);
                            Console.WriteLine(resultSearch);
                            break;

                        case EnumHasTableMethods.Exit:
                            isLooping = false;
                            break;

                        default:
                            Console.WriteLine("Method not found");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(" ******************** End Hash Table ******************** ");
        }
    }

    public enum EnumHasTableMethods
    {
        List = 1,
        Insert,
        Remove,
        SearchByKey,
        Exit
    }
}
