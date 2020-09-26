﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class Problem3
{
    public static int n;
    public static string[] ss;

    public static void Solve()
    {
        var dic =Enumerable.Range(0, 6).Select(s => new List<Tuple<int, int>>()).ToArray();
        for (int i = 0; i < n; i++)
        {
            var res = ReadAndSplitLine();

            dic[int.Parse(res[0])].Add(Pt(res[1]));
        }

        int d=0, tt=0, td=0;
        for (int i = 1; i < 6; i++)
        {
            bool isOk = false;
            for (int j = 0; j+59 <= 599; j++)
            {
                bool ok = true;
                foreach (var item in dic[i])
                {
                    if ((j >= item.Item1 && j <= item.Item2) || (j + 59 >= item.Item1 && j + 59 <= item.Item2)|| (j + 59 >= item.Item1 && j <= item.Item1) || (j + 59 >= item.Item2 && j <= item.Item2))
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    tt = j;
                    td = j + 59;
                    isOk = true;
                    break;
                }
            }

            if (isOk)
            {
                d = i;
                break;
            }
        }

        Console.WriteLine(d + " "+GetTime(tt)+"-"+GetTime(td));
    }

    static string GetTime(int t)
    {
        int h = (t / 60 + 8);
        var pp = h < 10 ? "0" + h.ToString() : h.ToString();

        int m = (t % 60);
        var pa = m < 10 ? "0" + m.ToString() : m.ToString();

        return pp + ":" + pa;
    }

    static Tuple<int, int> Pt(string time)
    {
       var nn = time.Split(new char[] { ':', '-' }).Select(int.Parse).ToArray();
        int t1 = (nn[0] - 8) * 60 + nn[1];
        int t2 = (nn[2] - 8) * 60 + nn[3];
        var res = new Tuple<int, int>(t1, t2);
        return res;
    }

    #region Main

    protected static TextReader reader;
    static void MainF(string[] args)
    {
#if false
        reader = new StreamReader(@"test\test.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        n = ReadInt();
 

        Solve();
        reader.Close();
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static long ReadLong() { return long.Parse(ReadToken()); }
    public static double ReadDouble() { return double.Parse(ReadToken(), CultureInfo.InvariantCulture); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static long[] ReadLongArray() { return ReadAndSplitLine().Select(long.Parse).ToArray(); }
    public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
    public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
    public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
    {
        int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
        for (int i = 0; i < ret.Length; i++) { ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++) ret[i][j] = matrix[j][i]; }
        return ret;
    }
    public static string ReadString() { return reader.ReadLine(); }
    public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
    public static string[][] ReadStringMatrix(int numberOfRows) { string[][] matrix = new string[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadAndSplitLine(); return matrix; }
    public static char[] ReadChars() { return reader.ReadLine().ToCharArray(); }
    private class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get { return ContainsKey(key) ? base[key] : default(TValue); }
            set { base[key] = value; }
        }
    }

    #endregion

    #region Functions
    private static T[] InitObjectArray<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret; }

    private static T[] InitNumberArray<T>(int size, T value) { var arr = new T[size]; for (int i = 0; i < size; i++) arr[i] = value; return arr; }

    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }

    private static void OutputArrayMatrix<T>(int[,] g, string sep = " ")
    {
        int m = g.GetLength(0);
        int n = g.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(g[i, j]+ (j==n-1 ? string.Empty : sep));
            }

            Console.WriteLine();
        }
    }

    private static void OutputArrayMatrix<T>(int[][] g, string sep = " ")
    {
        int n = g.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(string.Join(sep, g[i]));
        }
    }
    #endregion
}