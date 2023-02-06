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

class Result
{

    /*
     * Complete the 'cutTheSticks' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> cutTheSticks(List<int> arr)
    {  
        int[] arrNum = arr.ToArray();
        int minLen=1001;
        int cutCount=0;

        List<int> cuts=new List<int>();

        while(true){
            for(int i=0; i<arrNum.Length;i++){
                if(minLen>arrNum[i] && arrNum[i]>0)
                {
                    minLen=arrNum[i];
                }
            }
            for(int i=0; i<arrNum.Length;i++){
                if(arrNum[i]!=0){
                    cutCount++;
                    arrNum[i]=arrNum[i]-minLen;
                }
            }
            cuts.Add(cutCount);
            cutCount=0;

            if(arrNum.Max()==0){
                break;
            }

            minLen=1001;
        }

        return cuts;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.cutTheSticks(arr);

        Console.WriteLine(String.Join("\n", result));
    }
}