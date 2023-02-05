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
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

class Result
{

    /*
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {

        String timeInWords = " ";
        String[] NumbersToTwelve = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve" };
        String[] NumbersTo = {"ten","eleven","twelve","thirteen","fourteen","quarter","sixteen","seventeen"
                                            ,"eighteen","nineteen"};
        if (m == 0)
        {
            timeInWords = NumbersToTwelve[h-1] + " o' clock";
        }
        else if(m == 15)
        {
            timeInWords = "quarter" + " past " + NumbersToTwelve[h-1];
        }
        else if (m == 30)
        {
            timeInWords = "half past " + NumbersToTwelve[h - 1];
        }
        else if (m == 45)
        {
             timeInWords = "quarter to " + NumbersToTwelve[h];
        }
        else if (m > 30)
        {
            int reminder = 60 - m;
            if (reminder > 20)
            {
                timeInWords = "twenty " + NumbersToTwelve[reminder - 20 - 1] + " minutes to " + NumbersToTwelve[h];
            }
            else if (reminder < 20 && reminder > 12)
            {
                timeInWords = NumbersTo[reminder - 10] + " minutes to " + NumbersToTwelve[h];
            }
            else
            {
                timeInWords = NumbersToTwelve[reminder-1] + " minutes to " + NumbersToTwelve[h];
            }
        }   
        else
        {
            if (m > 20)
            {
                timeInWords = "twenty " + NumbersToTwelve[m - 21] + " minutes past " + NumbersToTwelve[h-1];
            }
            else if (m < 20 && m > 12)
            {
                timeInWords = NumbersTo[m - 11] + " minutes past " + NumbersToTwelve[h-1];
            }
            else
            {
                timeInWords = NumbersToTwelve[m - 1] + " minutes past " + NumbersToTwelve[h-1];
            }
        }

        return timeInWords;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        Console.WriteLine(result);
    }
}