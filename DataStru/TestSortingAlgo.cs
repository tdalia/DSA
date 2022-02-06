
namespace DataStru {
    class TestSortingAlgo {

        public void TestMergeSort() {
            SortingAlgo sa = new SortingAlgo();

            int[] arr = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            // sa.MergeSort(arr);

            arr = new int[] { 12, 11, 13, 5 };
            sa.MergeSortInPlace(arr, 0, arr.Length-1);

            sa = null;
            return;
        }
    }
}