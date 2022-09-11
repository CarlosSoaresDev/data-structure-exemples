namespace data_structure_app
{
    public class DataStructureFactory
    {
        public IList<IDataStructure> dataStructures = new List<IDataStructure>();

        public void Create<T>() where T : IDataStructure, new()
        {
            dataStructures.Add(new T());
        }

        public void Run()
        {
            foreach (var item in dataStructures)
            {
                item.Run();
            }
        }
    }

    public interface IDataStructure
    {
        void Run();
    }
}
