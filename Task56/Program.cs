// Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и 
// выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

void GetSumm(int[,] newArr)
{
    int[] sum = new int[newArr.GetLength(0)];
    for (int i = 0; i < newArr.GetLength(0); i++)
    {
        for (int j = 0; j < newArr.GetLength(1); j++)
        {
            sum[i] += newArr[i, j];
        }
    }
    int min = sum[0];
    int result = 0;
    for (int i = 0; i < sum.Length; i++)
    {
        if (sum[i] < min)
        {
            min = sum[i];
            result = i;
        }
    }
    Console.WriteLine($"Строка с меньшей суммой элементов: {result}");
}

int rows = GetNumber("Введите количество строк:");
int columns = GetNumber("Введите количество столбцов:");
int[,] matrix = InitMatrix(rows, columns);
PrintMatrix(matrix);
GetSumm(matrix);