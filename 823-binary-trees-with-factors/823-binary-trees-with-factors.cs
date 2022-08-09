public class Solution {
    public int NumFactoredBinaryTrees(int[] arr) {
        int mod = (int)1e9 + 7;
        
        Array.Sort(arr);
        
        long count = 1;
        Dictionary<int, long> dict = new();
        dict.Add(arr[0], count);
        
        for(int i = 1; i < arr.Length; i++)
        {
            count = 1;
            
            foreach(var k in dict.Keys)
            {
                if(arr[i] % k == 0 && dict.ContainsKey(arr[i] / k))
                    count += (dict[k] * dict[arr[i] / k]);
            }
            dict.Add(arr[i], count);
        }
        
        long sum = 0;
        foreach(var v in dict.Values)
            sum = (sum + v) % mod;
        
        return (int)sum;
    }
}

public class Solution1 {
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