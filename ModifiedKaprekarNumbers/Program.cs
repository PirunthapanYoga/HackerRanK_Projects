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
using System.Numerics;

class Result
{

    /*
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER q
     */
    public static void kaprekarNumbers(int p, int q)
    {
        long squareNum;
        String rightSideNumber;
        String leftSideNumber;
        int pLength;
        int sLength;
        bool foundFlag = false;

        while(p<=q)
        {
            pLength=p.ToString().Length;
            squareNum= (long)Math.Pow(p,2);
            sLength=squareNum.ToString().Length;
            rightSideNumber = squareNum.ToString().Substring(sLength-pLength);
            leftSideNumber = squareNum.ToString().Substring(0,sLength-pLength);

            if(sLength>1)
            {
                if(int.Parse(rightSideNumber)+int.Parse(leftSideNumber)==p )
                {
                    Console.Write(p);
                    foundFlag=true;
                    Console.Write(" ");
                }
            }else{
                if(squareNum==p){
                    Console.Write(p);
                    foundFlag=true;
                    Console.Write(" ");
                }
            }
            p++;
        }
        if(!foundFlag)
        {
            Console.WriteLine("INVALID RANGE");
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Result.kaprekarNumbers(p, q);
    }
}
