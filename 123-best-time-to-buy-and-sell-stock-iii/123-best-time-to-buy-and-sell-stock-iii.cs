//Space optimized
public class Solution {
    
    public int MaxProfit(int[] prices) {
        int[,] dpAfter = new int[2, 3]; //dp states
        int[,] dpCurrent = dpAfter;
        for (int i = prices.Length - 1; i >= 0; i--)
        {
            for (int k = 1; k <=2; k++)//Starts from 1 to 2
            {
                dpCurrent[0,k] = Math.Max(prices[i] + dpAfter[1, k-1], dpAfter[0, k]);
                dpCurrent[1,k] = Math.Max(-prices[i] + dpAfter[0, k], dpAfter[1, k]);
            }

            dpAfter = dpCurrent;
        }
            
        return dpCurrent[1,2];
    }
}

// Tabulation
public class SolutionTab {
    
    public int MaxProfit(int[] prices) {
        int[,,] dp = new int[prices.Length + 1, 2, 3]; //dp states
        //ArrayFill(dp, -1); //Time O(2n) // This is not required; because base case values are 0
        for (int i = prices.Length - 1; i >= 0; i--)
        {
            for (int buy = 0; buy <= 1; buy++)
            {
                for (int k = 1; k <=2; k++)//Starts from 1 to 2
                {
                    if (buy == 1)
                    {
                        dp[i,buy,k] = Math.Max(-prices[i] + dp[i+1, 0, k], dp[i+1, 1, k]);
                    }
                    else
                    {
                        dp[i,buy,k] = Math.Max(prices[i] + dp[i+1, 1, k-1], dp[i+1, 0, k]);
                    }
                }
            }
        }
            
        return dp[0,1,2];
    }
}
                                               

//Memoization - Reduce tran count on sell
public class Solution3 {
    public int MaxProfit(int[] prices) {
        int[,,] dp = new int[prices.Length, 2, 3]; //dp states
        ArrayFill(dp, -1); //Time O(2n)
        return MaxProfit(prices, 0, 1, 2, dp);
    }
    
    private int MaxProfit(int[] prices, int index, int buy, int k, int[,,] dp) {
        
        if (index == prices.Length || k <= 0) // NOTE: I need to add the condition here, because no more options available!
            return 0;

        if (dp[index,buy,k] != -1)
            return dp[index,buy,k];
        
        int profit = 0;
        if (buy == 1)
        {
            profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, k, dp), MaxProfit(prices, index + 1, 1, k, dp));
        }
        else
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1, k - 1, dp), MaxProfit(prices, index + 1, 0, k, dp));
        }
        
        return dp[index,buy,k] = profit;
    }
    
    //Time O(2n)
    private void ArrayFill(int[,,] dp, int value)
    {
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                for (int k = 0; k < dp.GetLength(2); k++)
                {
                    dp[i,j,k] = value;
                }                
            }
        }
    }
}

//Memoization
public class Solution2 {
    public int MaxProfit(int[] prices) {
        int[,,] dp = new int[prices.Length, 3, 2]; //dp states
        ArrayFill(dp, -1); //Time O(2n)
        return MaxProfit(prices, 0, 1, 2, dp);
    }
    
    private int MaxProfit(int[] prices, int index, int buy, int k, int[,,] dp) {
        
        if (index == prices.Length)// || k <= 0) // Because I still want to explore other options
            return 0;

        if (dp[index,k,buy] != -1)
            return dp[index,k,buy];
        
        int profit = 0;
        if (buy == 1)
        {
            if (k > 0)
                profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, k - 1, dp), MaxProfit(prices, index + 1, 1, k, dp));
            else
                profit = MaxProfit(prices, index + 1, 1, k, dp);
        }
        else
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1, k, dp), MaxProfit(prices, index + 1, 0, k, dp));
        }
        
        return dp[index,k,buy] = profit;
    }
    
    //Time O(2n)
    private void ArrayFill(int[,,] dp, int value)
    {
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                for (int k = 0; k < dp.GetLength(2); k++)
                {
                    dp[i,j,k] = value;
                }                
            }
        }
    }
}

// TLE
public class Solution1 {
    public int MaxProfit(int[] prices) {
        return MaxProfit(prices, 0, 1, 2);
    }
    
    private int MaxProfit(int[] prices, int index, int buy, int k) {
        
        if (index == prices.Length)// || k <= 0) // Because I still want to explore other options
            return 0;
        
        int profit = 0;
        if (buy == 1)
        {
            if (k > 0)
                profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, k - 1), MaxProfit(prices, index + 1, 1, k));
            else
                profit = MaxProfit(prices, index + 1, 1, k);
        }
        else
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1, k), MaxProfit(prices, index + 1, 0, k));
        }
        return profit;
    }
}