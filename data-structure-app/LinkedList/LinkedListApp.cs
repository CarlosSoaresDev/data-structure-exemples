namespace data_structure_app
{
    public class LinkedList : IDataStructure
    {
        public LinkedList<string> List(LinkedList<string> linkedList)
        {
            if (linkedList.Count <= 0)
                throw new ArgumentException("This linkedlist is empty");

            return linkedList;
        }

        public string Search(LinkedList<string> linkedList, string value)
        {
            return value;
        }

        public void InsertFirst(LinkedList<string> linkedList, string value)
        {
            linkedList.AddFirst(value);
        }

        public void InsertLast(LinkedList<string> linkedList, string value)
        {
            linkedList.AddLast(value);
        }

        public void InsertBefore(LinkedList<string> linkedList, string position, string value)
        {
            if (!linkedList.Any(a => a.Contains(position)))
                throw new ArgumentException($"node {position}, not found");

            var oldPosition = linkedList.FindLast(position);
            linkedList.AddBefore(oldPosition, value);
        }

        public void InsertAfter(LinkedList<string> linkedList, string position, string value)
        {
            if (!linkedList.Any(a => a.Contains(position)))
                throw new ArgumentException($"node {position}, not found");

            var oldPosition = linkedList.FindLast(position);
            linkedList.AddAfter(oldPosition, value);
        }

        [ExcludeFromCodeCoverage]
        public void Run()
        {
            Console.WriteLine("\n");
            Console.WriteLine(" ******************** Start Linked List ******************** ");
            var linkedList = new LinkedList<object>();

            bool isLooping = true;

            while (isLooping)
            {
                try
                {
                    Console.WriteLine("Select you Method ");
                    Console.WriteLine("\n1 - List \n2 - Insert First \n3 - Insert Last \n4 - Insert Before \n5 - Insert After \n6 - Remove \n7 - Search \n8 - Exit ");

                    var selectedMethod = (EnumLinkedListMethods)Convert.ToInt32(Console.ReadLine());

                    switch (selectedMethod)
                    {
                        case EnumLinkedListMethods.List:
                            break;
                        case EnumLinkedListMethods.InsertFirst:
                            break;
                        case EnumLinkedListMethods.InsertLast:
                            break;
                        case EnumLinkedListMethods.InsertBefore:
                            break;
                        case EnumLinkedListMethods.InsertAfter:
                            break;
                        case EnumLinkedListMethods.Remove:
                            break;
                        case EnumLinkedListMethods.Search:
                            break;
                        case EnumLinkedListMethods.Exit:
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(" ******************** End Linked List ******************** ");
        }

        public enum EnumLinkedListMethods
        {
            List = 1,
            InsertFirst,
            InsertLast,
            InsertBefore,
            InsertAfter,
            Remove,
            Search,
            Exit
        }
    }
}