public class Solution {
    public int MaxProfit(int[] prices) {
        int minLeft = prices[0];
        int maxProfit = 0;//int.MinValue; If only 1 item, it'd be 0
        for (int i = 1; i < prices.Length; i++)
        {
            minLeft = Math.Min(minLeft, prices[i - 1]);
            maxProfit = Math.Max(maxProfit, prices[i] - minLeft);
        }
        return maxProfit;
    }
}

//Throught to use 2 pointers min from left and max from right. But where to stop??
public class Solution1 {
    public int MaxProfit(int[] prices) {
        int left = 0;
        int right = prices.Length - 1;
        int minLeft = int.MaxValue;
        int maxRight = -1;
        while (left <= right)
        {
            minLeft = Math.Min(minLeft, prices[left]);
            maxRight = Math.Max(maxRight, prices[right]);
            left++;
            right--;
        }
        return 0;
    }
}