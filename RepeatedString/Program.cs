using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Net.Sockets;
using System.Xml.Schema;

class Result
{

    /*
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */

    public static long repeatedString(string s, long n)
    {
        long aCountInString=0;
        s.ToList().ForEach(delegate (char c) {
            if(c.Equals('a')){
                aCountInString++;
            }
        });

        long multiples= (n /s.Length);
        aCountInString =aCountInString*multiples;

        long reminder = n%s.Length;
        for(int i=0; i<reminder; i++){
            if(s.ElementAt(i).Equals('a')){
                aCountInString++;
            }
        }

        return aCountInString;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
       

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        Console.WriteLine(result);
    }
}
