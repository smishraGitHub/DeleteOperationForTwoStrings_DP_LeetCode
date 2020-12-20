using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteOperationForTwoStrings_DP_LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string p = "abcdaf";
            string q = "acbcf";
            int Result = 0;

            if (p.Length == 0)
            {
                Result = q.Length;
            }
            else if (q.Length == 0)
            {
                Result = p.Length;
            }
            else
            {

                int LCS_Length = LCS(p, q, p.Length, q.Length);

                Result = ((p.Length - LCS_Length) + (q.Length - LCS_Length));
            }
        }
        public static int LCS(string x, string y, int m, int n)
        {

            int[,] temp = new int[m + 1, n + 1];
            //Base Condition
            for (int i = 0; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0 || j == 0)
                        temp[i, j] = 0;
                }
            }
            //Choice Diagram

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (x[i - 1] == y[j - 1])
                    {
                        temp[i, j] = 1 + temp[i - 1, j - 1];
                    }
                    else
                    {
                        temp[i, j] = Math.Max(temp[i - 1, j], temp[i, j - 1]);
                    }
                }
            }
            return temp[m, n];
        }
    }
}
