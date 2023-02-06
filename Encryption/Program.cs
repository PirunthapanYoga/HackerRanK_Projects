using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;

class Result
{

    /*
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        String msg = "";
        s = s.Replace(" ", "");

        double SqrtLength = Math.Sqrt(s.Length);
        int row = (int)Math.Floor(SqrtLength);
        int col = (int)Math.Ceiling(SqrtLength);

        if (row * col < s.Length)
        {
            row++;
        }

        List<char> stoChar = s.ToCharArray().ToList<char>();
        char[,] charArray = new char[row, col];

        for (int k = 0; k < row; k++)
        {
            for (int l = 0; l < col; l++)
            {
                charArray[k, l] = ' ';
            }
        }

        int i = 0;
        int j = 0;

        stoChar.ForEach(delegate (char e)
        {
            charArray[i, j] = e;
            j++;
            if (j == col)
            {
                j = 0;
                i++;
            }
        });


        for (int jj = 0; jj < col; jj++)
        {
            for (int ii = 0; ii < row; ii++)
            {
                msg = msg + charArray[ii, jj];
                msg = msg.Trim(' ');
            }
            msg = msg + ' ';
        }
        msg = msg.Trim(' ');

        return msg;
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();

            string result = Result.encryption(s);

            Console.WriteLine(result);
        }
    }
