// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07 

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] array = new int[4, 4];
int[,] Spiral(int[,] array)
{
    int[,] newArr = array;
    int value = 1;
    for (int i = 0; i <= array.GetLength(0) / 2; i++)
    {
        for (int j = i; j < array.GetLength(0) - i; j++)
        {
            newArr[i, j] = value;
            value++;
        }
        for (int j = i + 1; j < array.GetLength(0) - i; j++)
        {
            newArr[j, array.GetLength(0) - 1 - i] = value;
            value++;
        }
        for (int j = array.GetLength(0) - 2 - i; j >= i; j--)
        {
            newArr[array.GetLength(0) - 1 - i, j] = value;
            value++;
        }
        for (int j = array.GetLength(0) - 2 - i; j > i; j--)
        {
            newArr[j, i] = value;
            value++;
        }
    }
    return newArr;
}

int[,] matrix = Spiral(array);
PrintMatrix(matrix);