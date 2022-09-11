public class Solution {
    public int MaximumProfit(int[] present, int[] future, int budget) {
        int[,] dp = new int[present.Length, budget + 1];
        ArrayFill(dp, -1);
        return MaximumProfit(present, future, 0, budget, dp);
    }
    
    private int MaximumProfit(int[] present, int[] future, int index, int budget, int[,] dp) {
        // NOTE: budget < 0 . Because stock price could be ZERO
        if (index == present.Length || budget < 0)
        {
            return 0;
        }
        
        if (dp[index, budget] != -1)
            return dp[index, budget];
        
        int buyProfit = -1;
        if(present[index] <= budget)//Needed otherwise we'd end up buying stock overbudget
            buyProfit = future[index] - present[index] + MaximumProfit(present, future, index + 1, budget - present[index], dp);
        int notBuyProfit = MaximumProfit(present, future, index + 1, budget, dp);
        return dp[index, budget] = Math.Max(buyProfit, notBuyProfit);
    }
    
    private void ArrayFill(int[,] dp, int value)
    {
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                dp[i,j] = value;
            }
        }
    }
}

//TLE
//Test: [0], [1], 0
public class SolutionTLE {
    public int MaximumProfit(int[] present, int[] future, int budget) {
        return MaximumProfit(present, future, 0, budget);
    }
    
    private int MaximumProfit(int[] present, int[] future, int index, int budget) {
        // NOTE: budget < 0 . Because stock price could be ZERO
        if (index == present.Length || budget < 0)
        {
            return 0;
        }
        
        int buyProfit = -1;
        if(present[index] <= budget)//Needed otherwise we'd end up buying stock overbudget
            buyProfit = future[index] - present[index] + MaximumProfit(present, future, index + 1, budget - present[index]);
        int notBuyProfit = MaximumProfit(present, future, index + 1, budget);
        return Math.Max(buyProfit, notBuyProfit);
    }
}