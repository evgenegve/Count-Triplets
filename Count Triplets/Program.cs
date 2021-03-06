﻿using System.CodeDom.Compiler;
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

class Solution
{

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r)
    {
        var dictC = new Dictionary<long, long>();
        var dictB = new Dictionary<long, long>();

        long triplets = 0;

        for (int i = arr.Count - 1; i >= 0; i--)
        {
            if (dictB.ContainsKey(arr[i] * r))
                triplets += dictB[arr[i] * r];

            if (dictC.ContainsKey(arr[i]*r))
            {
                if (dictB.ContainsKey(arr[i]))
                    dictB[arr[i]] += dictC[arr[i] * r];
                else
                    dictB.Add(arr[i], dictC[arr[i] * r]);
            }
            if (dictC.ContainsKey(arr[i]))
                dictC[arr[i]]++;
            else
                dictC.Add(arr[i], 1);
        }

        return triplets;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}