// See https://aka.ms/new-console-template for more information

using System;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Первые 10 чисел Фибоначчи:");
            int n1 = 0, n2 = 1, n3, i;
            Console.WriteLine(n1 + " " + n2 + " ");
            for (i = 2; i < 10; ++i) 
            {
                n3 = n1 + n2;
                Console.WriteLine(n3 + " ");
                n1 = n2;
                n2 = n3;
            }
            Console.WriteLine();

            // Задание 2: Вывести все чётные числа от 2 до 20
            Console.WriteLine("Чётные числа от 2 до 20:");
            for (i = 2; i <= 20; i += 2)
            {
                Console.WriteLine(i + " ");
            }
            Console.WriteLine();

            // Задание 3: Вывести таблицу умножения от 1 до 5
            Console.WriteLine("Таблица умножения от 1 до 5:");
            for (int j = 1; j <= 5; j++)
            {
                for (int k = 1; k <= 10; k++)
                {
                    Console.WriteLine(j + " * " + k + " = " + (j * k));
                }
                Console.WriteLine();   
            }

            // Задание 4: Ввод пароля с использованием do-while
            string password = "moon";
            string input;
            do
            {
                Console.WriteLine("Введите пароль:");
                input = Console.ReadLine();
                if (input != password)
                {
                    Console.WriteLine("Неверный пароль. Попробуйте снова.");
                }
            } while (input != password);
            Console.WriteLine("Пароль верный. Доступ разрешён.");
        }
    }
}
