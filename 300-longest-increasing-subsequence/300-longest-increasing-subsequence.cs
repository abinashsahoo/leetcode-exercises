public class Solution {
    public int LengthOfLIS(int[] nums) {
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);//Default 1
        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {                    
                    //dp[i] => Length of the longest increasing subsequence that ends with the i-th element
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        
        int longest = 0;
        foreach (int d in dp)
        {
            longest = Math.Max(longest, d);
        }
        return longest;
    }
}