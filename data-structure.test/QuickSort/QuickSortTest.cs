using data_structure_app;

namespace data_structure.test
{
    [ExcludeFromCodeCoverage]
    public class QuickSortTest
    {
        [Fact(DisplayName = "Should Success when change value in array")]
        public void ChangeValueSuccess()
        {
            //Arrange
            var entryData = new int[] { 59, 58, 20 };
            var expectedData = entryData.OrderBy(o => o);
            var quickSort = new QuickSort();

            //Action
            var result = quickSort.ChangeValue(entryData, 0, 2);

            //Assert
            Assert.True(result.SequenceEqual(expectedData));
        }

        [Fact(DisplayName = "Should Success when execute quick sort in array")]
        public void ExecuteQuickSortSuccess()
        {
            //Arrange
            var entryData = new int[] { 59, 58, 20, 40 };
            var expectedData = entryData.OrderBy(o => o);
            var quickSort = new QuickSort();

            //Action
            var result = quickSort.ExecuteSortQuick(entryData, 0, (entryData.Length - 1));

            //Assert
            Assert.True(result.SequenceEqual(expectedData));
        }

        [Fact(DisplayName = "Should Success when execute heapify in array")]
        public void PartitionSuccess()
        {
            //Arrange
            var entryData = new int[] { 20, 40, 58 };
            var expectedData = entryData.OrderByDescending(o => o);
            var quickSort = new QuickSort();

            //Action 
            var result = quickSort.Partition(entryData, 0, (entryData.Length - 1));

            //Assert
            Assert.Equal(0, result);
        }
    }
}
