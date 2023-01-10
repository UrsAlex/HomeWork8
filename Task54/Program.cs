// Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2 

int GetNumber(string message)
{
    int result = 0;
    while(true)
    {
        Console.WriteLine(message);
        if(int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.WriteLine("Ввели не число");
        }
    }
    return result;
}

int[,] InitMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i,j] = rnd.Next(1,10);
        }
    }
    return matrix;
}

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
int[,] GetStreamArray(int[,] array)
{
    int[,] streamArr = new int[array.GetLength(0), array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int k = 0; k < array.GetLength(1); k++)
        {
            for (int l = 0; l < array.GetLength(1); l++)
            {
                for (int j = 0; j < array.GetLength(1) - l - 1; j++)
                {

                    if (array[i, j] < array[i, j + 1])
                    {
                        int temp = array[i, j];
                        array[i, j] = array[i, j + 1];
                        array[i, j + 1] = temp;
                    }
                }
            }
            streamArr[i, k] = array[i, k];
        }
    }
    return streamArr;
}

int rows = GetNumber("Введите количество строк:");
int columns = GetNumber("Введите количество столбцов:");
int[,] matrix = InitMatrix(rows, columns);
PrintMatrix(matrix);
Console.WriteLine();
int[,] streamArr = GetStreamArray(matrix);
PrintMatrix(streamArr);
