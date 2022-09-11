using data_structure_app;
using System.Diagnostics.CodeAnalysis;

namespace data_structure.test.hash_table
{
    [ExcludeFromCodeCoverage]
    public class HashTableTest
    {
        [Fact(DisplayName = "Should Success when return hashtable with itens")]
        public void ListSuccess()
        {
            //Arrange
            var hastable = new Hashtable();
            var hashTableInstance = new HashTable();
            var mockListObject = new List<DictionaryEntry>()
            {
                new DictionaryEntry{ Key = 1, Value = "Jon Snow" },
                new DictionaryEntry { Key = 2, Value = "Aegon Targaryen" },
            };

            foreach (var mockObject in mockListObject)
            {
                hastable.Add(mockObject.Key, mockObject.Value);
            }

            //Action
            var result = hashTableInstance.List(hastable);

            //Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("Jon Snow", result[1].ToString());
        }

        [Fact(DisplayName = "Should error exception when hashtable is empty")]
        public void ListException()
        {
            //Arrange            
            var hashtable = new Hashtable();
            var hashTableInstance = new HashTable();

            //Action
            var result = Assert.Throws<ArgumentException>(() => hashTableInstance.List(hashtable));

            //Assert
            Assert.Contains($"This hastables is empty", result.Message);
        }

        [Fact(DisplayName = "Should Success when an item is found by key")]
        public void SearchByKeySuccess()
        {
            //Arrange
            var hastable = new Hashtable();
            var hashTableInstance = new HashTable();
            var mockObject = new DictionaryEntry { Key = 1, Value = "Jon Snow" };

            hastable.Add(mockObject.Key, mockObject.Value);

            //Action
            hashTableInstance.SearchByKey(hastable, mockObject.Key);

            //Assert
            Assert.Single(hastable);
            Assert.Equal(mockObject.Value, hastable[mockObject.Key]);
        }

        [Fact(DisplayName = "Should error exception when an item not is found by key")]
        public void SearchByKeyException()
        {
            //Arrange
            var hastable = new Hashtable();
            var hashTableInstance = new HashTable();
            var key = 1;

            //Action
            var result = Assert.Throws<ArgumentException>(() => hashTableInstance.SearchByKey(hastable, key));

            //Assert
            Assert.Contains($"Key {key}, not found", result.Message);
        }

        [Fact(DisplayName = "Should Success when an new value insert")]
        public void InsertSuccess()
        {
            //Arrange
            var hastable = new Hashtable();
            var hashTableInstance = new HashTable();
            var mockObject = new DictionaryEntry { Key = 1, Value = "Jon Snow" };

            //Action
            hashTableInstance.Insert(hastable, mockObject.Key, mockObject.Value);

            //Assert
            Assert.Single(hastable);
            Assert.Equal(mockObject.Value, hastable[mockObject.Key]);
        }

        [Fact(DisplayName = "Should error exception when exist value with current key")]
        public void InsertException()
        {
            //Arrange
            var hastable = new Hashtable();
            var hashTableInstance = new HashTable();
            var mockObject = new { key = 1, value = "Jon Snow" };
            hastable.Add(mockObject.key, mockObject.value);

            //Action
            var result = Assert.Throws<ArgumentException>(() => hashTableInstance.Insert(hastable, mockObject.key, mockObject.value));

            //Assert
            Assert.Contains("Item has already been added. Key in dictionary: '1'  Key being added: '1'", result.Message);
        }

        [Fact(DisplayName = "Should Success when an value removed")]
        public void RemoveSuccess()
        {
            //Arrange
            var hastable = new Hashtable();
            var hashTableInstance = new HashTable();
            var mockListObject = new List<DictionaryEntry>()
            {
                new DictionaryEntry{ Key = 1, Value = "Jon Snow" },
                new DictionaryEntry { Key = 2, Value = "Aegon Targaryen" },
            };
            foreach (var mockObject in mockListObject)
            {
                hastable.Add(mockObject.Key, mockObject.Value);
            }

            //Action
            hashTableInstance.Remove(hastable, mockListObject[0].Key);

            //Assert
            Assert.Single(hastable);
            Assert.Equal(mockListObject[1].Value, hastable[mockListObject[1].Key]);
        }

        [Fact(DisplayName = "Should error exception when key not found to remove")]
        public void RemoveException()
        {
            //Arrange
            var hastable = new Hashtable();
            var hashTableInstance = new HashTable();
            var key = 1;

            //Action
            var result = Assert.Throws<ArgumentException>(() => hashTableInstance.Remove(hastable, key));

            //Assert
            Assert.Contains($"Key {key}, not found", result.Message);
        }
    }
}
