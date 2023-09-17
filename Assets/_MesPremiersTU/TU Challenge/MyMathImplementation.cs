using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge
{
    public class MyMathImplementation
    {
        internal static int Add(int a, int b)
        {
            return a + b;
        }

        internal static List<int> GenericSort(List<int> toSort, Func<int, int, bool> isInOrder)
        {
            var sorted = Sort(toSort); // sorted is ascending
            for (int i = 0; i < (sorted.Count * 0.5f); i++)
            {
                if(!isInOrder(sorted[i], sorted[sorted.Count - 1 - i]))
                    (sorted[i], sorted[sorted.Count - 1 - i]) = (sorted[sorted.Count - 1 - i], sorted[i]);
            }

            return sorted;
        }

        internal static List<int> GetAllPrimary(int a)
        {
            List<int> ret = new();
            if (a < 2) return new List<int>();

            for (int i = 2; i <= a; i++)
                if(IsPrimary(i))
                    ret.Add(i);

            return ret;
        }

        internal static bool IsDivisible(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("Can't divide by 0");
            
            return a % b == 0;
        }

        internal static bool IsEven(int a)
        {
            return a % 2 == 0;
        }

        internal static bool IsInOrder(int a, int b)
        {
            return a <= b;
        }

        internal static bool IsInOrderDesc(int arg1, int arg2)
        {
            return arg1 >= arg2;
        }

        internal static bool IsListInOrder(List<int> list)
        {
            for(int i = 0; i < list.Count - 1; i++)
                if (list[i] > list[i+1]) return false;

            return true;
        }

        internal static bool IsMajeur(int age)
        {
            if (age < 0)
                throw new ArgumentException("Age can\'t be negative.");
            
            if(age > 140)
                throw new ArgumentException("Age can\'t be larger than 140.");
            
            return age >= 18;
        }

        internal static bool IsPrimary(int a)
        {
            if (a < 0 || a == 1) return false;
            if (a == 2 || a == 5 || a == 7) return true;
            
            for (int i = (int)SquareRoot(a); i >= 2; i--)
            {
                if (a % i == 0) return false;
            }

            return true;
        }

        internal static float SquareRoot(float a)
        {
            if (a < 0)
                throw new ArgumentException("a can't be negative.");
            
            // Methode de Newton 
            float i = 0;
            float j = a / 2;

            while (!IsEqual(j, i)) {
                i = j;
                j = (a / i + i) / 2;
            }
  
            return j;
        }

        internal static bool IsEqual(float a, float b, float epsilon = .0001f)
        {
            float diff = a - b;
            if (diff < 0) diff *= -1;

            return diff <= epsilon;
        }
        
        internal static int Power(int a, int exponent)
        {
            //if (exponent < 0) return 1 / Power(a, -exponent); 
            if (exponent < 0) return 0; // because this function returns an int.

            int result = 1;
            for (int i = 0; i < exponent; i++)
                result *= a;

            return result;
        }

        internal static int Power2(int a) => a * a;

        internal static List<int> Sort(List<int> toSort)
        {
            List<int> sortedList = toSort;
            while (!IsListInOrder(sortedList))
            {
                for (int i = 0; i < sortedList.Count - 1;)
                {
                    if (sortedList[i] > sortedList[i + 1])
                    {
                        (sortedList[i], sortedList[i + 1]) = (sortedList[i + 1], sortedList[i]);
                        if (i > 0) i--;
                    }
                    else
                        i++;
                }
            }
            return sortedList;
        }
    }
}
