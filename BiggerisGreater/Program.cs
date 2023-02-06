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
using System.Runtime.CompilerServices;
using System.Data;

class Result
{

    /*
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string GetString(byte[] stringArrray)
    {
        return System.Text.Encoding.ASCII.GetString(stringArrray);
    }

    public static int CompareString(String strLexo, string strModifiedLexo)
    {
        return strLexo.CompareTo(strModifiedLexo);
    }

    public static void PrintArr(byte[] byteArr)
    {
        byteArr.ToList().ForEach(delegate (byte b)
        {
            Console.Write(b);
        });
        Console.WriteLine();
    }

    public static string biggerIsGreater(string w)
    {
        byte[] stringArray = Encoding.ASCII.GetBytes(w);
        byte[] backUpStringGreaterArray = stringArray;
        // PrintArr(stringArray);

        int arrayLength=stringArray.Length;

        byte secondSmall=stringArray[arrayLength-2];;
        int  secondSmallIndex=arrayLength-2;
        byte temp=0;
        bool flag =false;

        for (int i=arrayLength-1; i>=0; i--)
        {
            for(int j =i-1 ;j>=0; j--)
            {
                if(stringArray[i]>=stringArray[j])
                { 
                    if(secondSmall<=stringArray[j])
                    {
                        secondSmallIndex=j;
                        secondSmall=stringArray[j];
                        flag =true;
                    }

                    String x=GetString(stringArray);
                    String y=GetString(backUpStringGreaterArray);

                    if(CompareString(y,x)==1)
                    {
                        backUpStringGreaterArray=stringArray;
                    }
                    else
                    {
                        stringArray=backUpStringGreaterArray;
                    }

                }
                
            }
            if(flag){
                temp = stringArray[i];
                stringArray[i]=stringArray[secondSmallIndex];
                stringArray[secondSmallIndex] = temp;
            }
        }

        String z=GetString(backUpStringGreaterArray);
        Console.WriteLine(z);
        String ret="no answer";
        if(CompareString(w,z)==-1)
        {
            ret =z;
        }
        return ret;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
         int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            Console.WriteLine(result);
        }
    }
}
 
