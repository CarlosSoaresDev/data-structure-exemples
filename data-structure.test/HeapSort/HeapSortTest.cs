using data_structure_app;

namespace data_structure.test
{
    [ExcludeFromCodeCoverage]
    public class HeapSortTest
    {
        [Fact(DisplayName = "Should Success when change value in array")]
        public void ChangeValueSuccess()
        {
            //Arrange
            var entryData = new int[] { 59, 58, 20 };
            var expectedData = entryData.OrderBy(o => o);
            var heapSort = new HeapSort();

            //Action
            var result = heapSort.ChangeValue(entryData, 0, 2);

            //Assert
            Assert.True(result.SequenceEqual(expectedData));
        }

        [Fact(DisplayName = "Should Success when execute heap sort in array")]
        public void ExecuteHeapSortSuccess()
        {
            //Arrange
            var entryData = new int[] { 59, 58, 20, 40};
            var expectedData = entryData.OrderBy(o => o);
            var heapSort = new HeapSort();            

            //Action
            var result = heapSort.ExecuteHeapSort(entryData);

            //Assert
            Assert.True(result.SequenceEqual(expectedData));
        }

        [Fact(DisplayName = "Should Sucess when execute heapify in array")]
        public void HeapifySuccess()
        {
            //Arrange
            var entryData = new int[] { 20, 40, 58  };
            var expectedData = entryData.OrderByDescending(o => o);
            var heapSort = new HeapSort();

            //Action 
              var result =  heapSort.Heapify(entryData, entryData.Length, 0);
            
            //Assert
            Assert.True(result.SequenceEqual(expectedData));
        }
    }
}
