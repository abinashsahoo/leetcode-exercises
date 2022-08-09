public class Solution {
    public int NumFactoredBinaryTrees(int[] arr) {
        long response = 0;
        int mod = (int)1e9 + 7;
        
        Array.Sort(arr);
        
        var dp = new long[arr.Length];
        Array.Fill(dp, 1);
        
        Dictionary<int, int> dict = new();
        for (int i = 0; i < arr.Length; i++)
        {
            dict[arr[i]] = i;            
        }
        
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (arr[i] % arr[j] == 0)// arr[j] is left child
                {
                    int right = arr[i] / arr[j];
                    if (dict.ContainsKey(right))
                    {
                        dp[i] = (dp[i] + dp[j] * dp[dict[right]]) % mod;
                    }
                }
            }
        }
        
        foreach (long d in dp)
        {
            response = (response + d) % mod;
        }
        
        return (int)response;
    }
}