using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  1.  Реализовать сортировку подсчётом.
    2.  Реализовать быструю сортировку.
    3.  *Реализовать сортировку слиянием.
    4.  **Реализовать алгоритм сортировки со списком.
    5.  Проанализировать время работы каждого из вида сортировок для 100, 10000, 1000000 элементов. Заполнить таблицу.

    Александр Кушмилов
*/


namespace GB_Algorithms_8
{
    class Program
    {
        /// <summary>
        /// Метод сортировки посчетом.
        /// </summary>
        /// <param name="arr"></param>
        static void CountingSort(int[] arr)
        {
            int[] freqArr = new int[arr.Max()+1];
            for (int i = 0; i < arr.Length; i++)
            {
                freqArr[arr[i]]++;
            }
            int x = 0;
            for (int k = 0; k < freqArr.Length; k++)
            {
                for (int j = 0; j < freqArr[k]; j++)
                {
                    arr[x++] = k;
                }
            }
        }

        // Не доделан
        static void Quicksort(int[] arr, int start, int end)
        {
            int middle = (end - start) / 2;
            while (start != end - 1)
            {
                while (arr[start] <= arr[middle] && start < middle - 1)
                {
                    start++;
                }
                while (arr[end] > arr[middle] && end > middle)
                {
                    end--;
                }
                if (arr[start] > arr[end])
                {
                    arr[start] = arr[start] ^ arr[end];
                    arr[end] = arr[end] ^ arr[start];
                    arr[start] = arr[start] ^ arr[end];
                }
            }
            if (start < middle - 1) Quicksort(arr, start, middle - 1);
            if (middle < end) Quicksort(arr, middle, end);
        }


        /// <summary>
        /// Метод заполняет массив случайными числами от 0 до max
        /// </summary>
        /// <param name="array">Заполняемый массив</param>
        /// <param name="max">Максимальное значение</param>
        static void RndArrValue(int[] array, int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(max);
            }
        }

        /// <summary>
        /// Метод выводит массив в консоль
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArr(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] referenceArray = new int[20];
            RndArrValue(referenceArray, 100);
            PrintArr(referenceArray);

            int[] arr1 = new int[referenceArray.Length];
            Array.Copy(referenceArray, arr1, referenceArray.Length);
            CountingSort(arr1);
            PrintArr(arr1);

            Array.Copy(referenceArray, arr1, referenceArray.Length);
            Quicksort(arr1, 0, arr1.Length - 1);
            PrintArr(arr1);

            Console.ReadKey();
        }

    }
}
