// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

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

int[,,] InitArray(int a, int b, int c)
{
    int[,,] matrix = new int[a, b, c];
    Random rnd = new Random();
    bool Unique(int randomNumber)
    {
        for (int i = 0; i < a; i++)
        {
           for (int j = 0; j < b; j++)
           {
                for (int k = 0; k < c; k++)
                {
                   if (matrix[i, j, k] == randomNumber)
                    return true; 
                } 
            }
        }
        return false;
    }
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < b; j++)
        {
           for (int k = 0; k < c; k++)
            {
                int num;
                do
                {
                    num = rnd.Next(10, 100);
                } 
                while (Unique(num));
                matrix[i, j, k] = num;
            } 
        }
    }    
    return matrix;
}

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($"{matrix[i,j,k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine();
}

int a = GetNumber("Введите размерность a массива:");
int b = GetNumber("Введите размерность b массива:");
int c = GetNumber("Введите размерность c массива:");
Console.WriteLine();
int[,,] matrix = InitArray(a, b, c);
PrintMatrix(matrix);