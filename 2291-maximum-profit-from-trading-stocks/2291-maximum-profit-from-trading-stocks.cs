public class Solution {
    public int MaximumProfit(int[] present, int[] future, int budget) {
        int[] dp = new int[budget + 1];
        for (int i = present.Length - 1; i >= 0; i--)
        {
            for (int b = budget; b >= 0 ; b--)
            {
                if(b >= present[i])
                {
                    dp[b] = Math.Max(dp[b], future[i] - present[i] + dp[b - present[i]]); 
                }                      
            }
        }
        return dp[budget];
    }
}

//Memory Optimization - Clean
public class Solution11 {
    public int MaximumProfit(int[] present, int[] future, int budget) {
        int[] dp = new int[budget + 1];
        for (int i = present.Length - 1; i >= 0; i--)
        {
            for (int b = budget; b >= 0 ; b--)
            {
                if(present[i] <= b)
                {
                    dp[b] = Math.Max(dp[b], future[i] - present[i] + dp[b - present[i]]); 
                }                      
            }
        }
        return dp[budget];
    }
}

//Memory Optimization
public class Solution1 {
    public int MaximumProfit(int[] present, int[] future, int budget) {
        int[] after = new int[budget + 1]; 
        //int[] current = after; //new int[budget + 1]; We technically don't need
        for (int index = present.Length - 1; index >= 0; index--)
        {
            for (int b = budget; b >= 0 ; b--) //Order matters because we are dealing with same array. Otherwise we need CopyTo
            //for (int b = 0; b <= budget; b++)
            {
                int buyProfit = -1;
                if(present[index] <= b)//Needed otherwise we'd end up buying stock overbudget
                {
                    buyProfit = future[index] - present[index] + after[b - present[index]];
                }
                int notBuyProfit = after[b];

                after[b] = Math.Max(buyProfit, notBuyProfit);       
            }
            
            //after = current;
            //current.CopyTo(after, 0);
        }
        return after[budget];
    }
}

//Iterative
public class SolutionIterative {
    public int MaximumProfit(int[] present, int[] future, int budget) {
        //If it's a value add + 1. For Iterative, arr Length + 1, because in the code we are using index + 1
        int[,] dp = new int[present.Length + 1, budget + 1]; 
        
        for (int index = present.Length - 1; index >= 0; index--)
        {
            for (int b = 0; b <= budget; b++)
            {
                int buyProfit = -1;
                if(present[index] <= b)//Needed otherwise we'd end up buying stock overbudget
                {
                    buyProfit = future[index] - present[index] + dp[index + 1, b - present[index]];
                }
                int notBuyProfit = dp[index + 1, b];

                dp[index, b] = Math.Max(buyProfit, notBuyProfit);       
            }
        }
        return dp[0, budget];
    }
}

//Memo
public class SolutionMemo {
    public int MaximumProfit(int[] present, int[] future, int budget) {
        int[,] dp = new int[present.Length, budget + 1]; //If it's a value add + 1
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