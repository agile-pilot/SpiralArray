using SpiralArray;

internal class Program
{
    private static void Main(string[] args)
    {
        int m = 4;
        int n = 5;
        int[,] array = new int[m, n];
        int number = 1;
        var navigator = new Navigator(m, n);

        while (number <= m * n)
        {
            var currentCell = navigator.GetNextCell();
            array[currentCell.ColumnIndex, currentCell.RowIndex] = number;
            number++;
        }

        PrintArray(array);

        Console.ReadLine();
    }

    private static void PrintArray(int[,] array)
    {
        for (int a = 0; a < array.GetLength(0); a++)
        {
            for (int b = 0; b < array.GetLength(1); b++)
            {
                Console.Write($"{array[a, b].ToString("D2")} ");
            }
            Console.WriteLine();

        }
    }
}