using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge
{
    public class MyStringImplementation
    {
        internal static string BazardString(string input)
        {
            if (input == null || input == "") throw new ArgumentException();
            
            string keptChars = "";
            string ignoredChars = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                    keptChars += input[i];
                else
                    ignoredChars += input[i];
            }

            return keptChars += ignoredChars;
        }

        internal static bool IsNullEmptyOrWhiteSpace(string input)
        {
            if (input == null || input == "") return true;

            foreach (var c in input)
                if (c != ' ') return false;

            return true;
        }

        internal static string MixString(string a, string b)
        {
            if (a == null || a == "" || b == null || b == "")
                throw new ArgumentException();
            
            string ret = "";
            int longestLength = a.Length + b.Length;
            
            int i = 0;
            while (ret.Length < longestLength)
            {
                if (i < a.Length)
                    ret += a[i];

                if (i < b.Length)
                    ret += b[i];

                i++;
            }

            return ret;
        }

        internal static string ToCesarCode(string input, int offset)
        {
            input = ToLowerCase(input);
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c >= 'a' && c <= 'z')
                {
                    if(c + offset <= 'z') 
                        output += (char)(c + offset);
                    else
                    {
                        c = (char)('a' + (c + offset - 'z' - 1));
                        output += c;
                    }
                }
                else
                    output += c;
            }

            return output;
        }

        internal static string ToLowerCase(string a)
        {
            if (a == null || a == "") throw new ArgumentException();
            
            string ret = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= 'A' && a[i] <= 'Z')
                    ret += (char)(a[i] + 32); // 32 is the "distance" between a UpperCase letter and its lowercase letter
                else
                    ret += a[i];
            }

            return ret;
        }

        internal static string UnBazardString(string input)
        {
            if (input == null || input == "") throw new ArgumentException();

            char[] chars = new char[input.Length];
            int iLength = (input.Length / 2) + input.Length % 2;
            
            for (int i = 0; i < iLength; i++)
            {
                chars[i * 2] = input[i];
                
                if(i + iLength < input.Length)
                    chars[i * 2 + 1] = input[i + iLength];
            }

            return new string(chars);
        }

        internal static string Voyelles(string a)
        {
            if (a == null || a == "") throw new ArgumentException();
            
            char[] vowels = {'a', 'e', 'i', 'o', 'u', 'y'};
            a = ToLowerCase(a);
            string ret = "";

            foreach (char c in a)
            {
                if (vowels.Contains(c) & !ret.Contains(c))
                    ret += c;
            }

            return ret;
        }

        internal static string Reverse(string a)
        {
            if (a == null || a == "") throw new ArgumentException();

            string ret = "";
            for (int i = a.Length - 1; i >= 0; i--)
                ret += a[i];

            return ret;
        }
    }
}
