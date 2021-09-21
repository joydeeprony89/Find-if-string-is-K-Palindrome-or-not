using System;

namespace Find_if_string_is_K_Palindrome_or_not
{
    // https://www.geeksforgeeks.org/find-if-string-is-k-palindrome-or-not/
    // https://www.youtube.com/watch?v=We3YDTzNXEk
    // https://www.youtube.com/watch?v=GhoU-V41XQY
    class Program
    {
        static void Main(string[] args)
        {
            string s = "acdcb"; // abcdecba, k = 1 // "abcdeca", k = 2
            int k = 2;
            Console.WriteLine(IsKPalindromic(k, s));
        }

        static bool IsKPalindromic(int k, string s)
        {
            string revStr = s;
            revStr = Reverse(revStr);
            var result = IsPalindrominDP(s, revStr, s.Length, s.Length);
            return result <= 2 * k;
        }

        static int IsPalindrominDP(string str1, string str2, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                        dp[i, j] = j;

                    else if (j == 0)
                        dp[i, j] = i;
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[m, n];
        }

        static string Reverse(string revStr)
        {
            var arr = revStr.ToCharArray();
            for (int l = 0, r = revStr.Length - 1; l < r; l++, r--)
            {
                char t = arr[l];
                arr[l] = arr[r];
                arr[r] = t;
            }

            return string.Join("", arr);
        }
    }
}
