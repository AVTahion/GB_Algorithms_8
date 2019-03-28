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
        /// Метод сортировки подсчетом.
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

        /// <summary>
        /// Метод сортировки Хоара
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        static void Quicksort(int[] arr, int start, int end)
        {
            int middle = arr[(end - start) / 2 + start];
            int temp;
            int S = start;
            int E = end;
            while (S <= E)
            {
                while (arr[S] < middle && S <= end)
                {
                    S++;
                }
                while (arr[E] > middle && E >= start)
                {
                    E--;
                }
                if (S <= E)
                {
                    temp = arr[S];
                    arr[S] = arr[E];
                    arr[E] = temp;
                    S++;
                    E--;
                }
            }
            if (E > start) Quicksort(arr, start, E);
            if (S < end) Quicksort(arr, S, end);
        }

        /// <summary>
        /// Метод сортировки слиянием
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }
            int middle = arr.Length / 2;
            return Merge(MergeSort(arr.Take(middle).ToArray()), MergeSort(arr.Skip(middle).ToArray()));
        }

        /// <summary>
        /// Метод слияния подмассивов
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        static int[] Merge(int[] arr1, int[] arr2)
        {
            int ptr1 = 0, ptr2 = 0;
            int[] merged = new int[arr1.Length + arr2.Length];

            for (int i = 0; i < merged.Length; i++)
            {
                if (ptr1 < arr1.Length && ptr2 < arr2.Length)
                {
                    merged[i] = arr1[ptr1] > arr2[ptr2] ? arr2[ptr2++] : arr1[ptr1++];
                }
                else
                {
                    merged[i] = ptr2 < arr2.Length ? arr2[ptr2++] : arr1[ptr1++];
                }
            }
            return merged;
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

            Array.Copy(referenceArray, arr1, referenceArray.Length);
            arr1 = MergeSort(arr1);
            PrintArr(arr1);

            Console.ReadKey();
        }

    }
}
