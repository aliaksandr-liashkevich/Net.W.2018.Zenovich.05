namespace Net.W._2018.Zenovich._05.API
{
    public interface IJaggedArrayUtils
    {
        int[][] MinSort(int[][] jaggedArray, OrderdBy orderdBy = OrderdBy.Ascending);
        int[][] MaxSort(int[][] jaggedArray, OrderdBy orderdBy = OrderdBy.Ascending);
        int[][] SumSort(int[][] jaggedArray, OrderdBy orderdBy = OrderdBy.Ascending);
    }
}
