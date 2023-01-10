// Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18 

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

(int[,], int[,]) InitMatrix(int rows, int columns1, int columns2)
{
    int[,] matrix1 = new int[rows, columns1];
    int[,] matrix2 = new int[columns1, columns2];
    Random rnd = new Random();
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            matrix1[i,j] = rnd.Next(1,10);
        }
    }
    for (int i = 0; i < matrix2.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            matrix2[i,j] = rnd.Next(1,10);
        }
    }
    return (matrix1, matrix2);
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

int [,] GetWisMatrix(int[,] matrix1, int[,] matrix2)
{
    int [,] matrix3 = new int [matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                
                matrix3[i,j] +=  matrix1[i,k] * matrix2[k,j];
            }
        }
    return matrix3;
}

int rows = GetNumber("Введите количество строк матрицы 1:");
int columns1 = GetNumber("Введите количество столбцов матрицы 1:");
int columns2 = GetNumber("Введите количество столбцов матрицы 2:");
(int[,] matrix1, int[,] matrix2) = InitMatrix(rows, columns1, columns2);
int[,] matrix3 = GetWisMatrix(matrix1, matrix2);
Console.WriteLine();
PrintMatrix(matrix1);
PrintMatrix(matrix2);
PrintMatrix(matrix3);
