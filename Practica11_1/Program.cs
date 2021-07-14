using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Practica11_1
{
    class Program
    {
        //Напечатать матрицу:
        static void arrPrint(int[] ar) {
            //Число элементов матрицы:
            int nn = ar.GetUpperBound(0);
            for (int i = 0; i <= nn; i++)
                    Console.Write("{0,4:d}",ar[i]);
        }
        //Сформировать матрицу со случайными элементами:
        static int[] getArray(int n) {
            Random generator = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) {
                arr[i] = generator.Next(-50, 51); //массив элементов типа int
            }
            return arr;
        }
        //Метод, возвращающий массив индексов локальных минимумов:
        static void compare(int[] arr)
        {
            ArrayList arr2 = new ArrayList();
            int i = 0, k = 0;
            //Оценка минимальности первого элемента
            if (arr[i] < arr[i + 1])
            {
                arr2.Add(i);
                k++;
            }
            //Оценка минимальности всех элементов кроме первого и последнего
            for (i = 1; i < arr.Length - 1 ; i++)
            {
                if (arr[i] < arr[i - 1] && arr[i] < arr[i + 1])
                {
                    arr2.Add(i);
                    k++;
                }
            }
            //Оценка минимальности последнего элемента
            if (arr[arr.Length - 1] < arr[arr.Length - 2])
            {
                arr2.Add(arr.Length - 1);
                k++;
            }
            for (int j = 0; j < k; j++)
                Console.Write("{0,4:d}", arr2[j]);
        }
        static void Main()
        {
            int[] array;
            int size;       //размер матрицы
            do {            //Цикл повторения решений
                do          //Цикл контроля ввода:
                    Console.Write("Введите размер матрицы:");
                    while (!int.TryParse(Console.ReadLine(), out size) | size <= 0) ;
                    array = getArray(size);
                    Console.WriteLine("Исходная матрица:");
                    arrPrint(array);
                    Console.WriteLine("\nВывод  индексов всех элементов, значения которых меньше значений соседних элементов");
                    compare(array);
                    Console.WriteLine();
                    Console.WriteLine("Для выхода из программы нажмите ESC.");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        } //Main()
    }
}
