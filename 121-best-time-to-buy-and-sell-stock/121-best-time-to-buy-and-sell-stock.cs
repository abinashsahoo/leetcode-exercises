//Do I need to buy the stock before selling?
    
//using 2 pointer
public class Solution {
    public int MaxProfit(int[] prices) {
        int left = 0;
        int right = 1;
        int maxProfit = 0;
        while(right < prices.Length)
        {
            //if profitable
            if (prices[right] > prices[left])
            {
                maxProfit = Math.Max(maxProfit, prices[right] - prices[left]);
            }
            else //Found a new low
            {
                left = right; //NOT left++;
            } 
            right++;
        }
        return maxProfit;
    }
    
    
//Throught to use 2 pointers min from left and max from right. But where to stop??
    public int MaxProfit1(int[] prices) {
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

public class Solution3 {
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

public class Solution2 {
    public int MaxProfit(int[] prices) {
        
        // if (prices.Length < 2)
        // {
        //     throw new ArgumentException("Getting a profit requires at least 2 prices", nameof(prices));
        // }
        
        int lowest = prices[0];
        int maxProfit = 0;//prices[1] - prices[0]; if we want to retutn loss when price never increases
        for (int i = 1; i < prices.Length; i++)
        {
            maxProfit = Math.Max(maxProfit, prices[i] - lowest);//This calculation has to happen first
            lowest = Math.Min(lowest, prices[i]);//This one after profit calc; because Minprice should come first
        }
        
        return maxProfit;
    }
    
    //Brute force O(n^2)
    public int MaxProfit0(int[] prices) {
        
        int maxProfit = 0;
        for (int i = 0; i < prices.Length - 1; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                maxProfit = Math.Max(maxProfit, prices[j] - prices[i]);
            }
        }
        return maxProfit;
    }
}