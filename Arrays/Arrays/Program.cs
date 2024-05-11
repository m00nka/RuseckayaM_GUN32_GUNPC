// See https://aka.ms/new-console-template for more information

using System;

namespace HomeWork
{ 
class Program
{
    static void Main(string[] args)
    {
        // Задание 1: Числа Фибоначчи
        int[] fibonacci = new int[8];
        fibonacci[0] = 0;
        fibonacci[1] = 1;
        for (int i = 2; i < 8; i++)
        {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
        }

        // Задание 2: Названия месяцев
        string[] months = new string[]
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        };

        // Задание 3: Двумерный массив (матрица)
        int[,] matrix = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrix[i, j] = (int)Math.Pow(j + 2, i + 1);
            }
        }

        // Задание 4: Ломанный массив
        double[][] jaggedArray = new double[][]
        {
            new double[] {1, 2, 3, 4, 5},
            new double[] {Math.E, Math.PI},
            new double[] {Math.Log10(1), Math.Log(10), Math.Log10(100), Math.Log10(1000)}
        };

        // Вывод результатов
        Console.WriteLine("Задание 1: Числа Фибоначчи");
        Console.WriteLine(string.Join(", ", fibonacci));
        Console.WriteLine("Задание 2: Названия месяцев");
        Console.WriteLine(string.Join(", ", months));
        Console.WriteLine("Задание 3: Матрица");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Задание 4: Ломанный массив");
        foreach (var array in jaggedArray)
        {
            Console.WriteLine(string.Join(", ", array));
        }

            // Массивы для заданий 5 и 6
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            // Задание 5: Скопировать первые 3 элемента первого массива во второй
            Array.Copy(array1, array2, 3);

            Console.WriteLine("Задание 5 и 6:");
            Console.WriteLine("Измененный второй массив:");
            foreach (int num in array2)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Задание 6: Увеличить размер первого массива в два раза
            Array.Resize(ref array1, array1.Length * 2);
            Console.WriteLine("Увеличенный первый массив:");
            foreach (int num in array1)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
