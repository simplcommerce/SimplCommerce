using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.ProductsRecommendation.Common
{
    public static class Helper
    {
        private static IEnumerable<int[]> CombinationsRosettaWoRecursion(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>(m);
            stack.Push(0);
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();
                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);

                    if (index != m) continue;
                    yield return (int[])result.Clone();

                    break;
                }
            }
        }

        public static IEnumerable<T[]> CombinationsRosettaWoRecursion<T>(T[] array, int m)
        {
            T[] result = new T[m];
            foreach (int[] j in CombinationsRosettaWoRecursion(m, array.Length))
            {
                for (int i = 0; i < m; i++)
                {
                    result[i] = array[j[i]];
                }
                yield return result;
            }
        }
    }
}
