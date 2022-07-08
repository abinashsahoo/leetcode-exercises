public class Solution {
    
    int?[,,] memo = null;
    const int MaxCost = (int)1e6 + 1;//Maximum cost possible plus 1
    
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target) 
    {   
        memo = new int?[houses.Length, houses.Length, n + 1];
        var result = FindMinCost (houses, cost, target, 0, 0, 0);
        return result == MaxCost ? -1 : result;
    }
    
    private int FindMinCost (int[] houses, int[][] cost, int target, int houseIndex, int neighborCount, int prevColor)
    {
        if(houseIndex == houses.Length)// not houses.Length - 1
        {
            return neighborCount == target ? 0 : MaxCost;
        }
        
        if(neighborCount > target)//No need to calculate further!
        {
            return MaxCost;
        }        
        
        if(memo[houseIndex, neighborCount, prevColor] != null)
        {            
            return (int)memo[houseIndex, neighborCount, prevColor];
        }
        
        int minCost = MaxCost;
        int currentColor = houses[houseIndex];
        //If house is already painted
        if(currentColor != 0)
        {
            //neighborCount += (prevColor == currentColor) ? 0 : 1;//Must not motify the parameters
            int newNeighborCount = neighborCount + (prevColor == currentColor ? 0 : 1);
            //NOTE: currentColor - 1
            //NOTE: Don't add the current cost
            int currentCost = FindMinCost (houses, cost, target, houseIndex + 1, newNeighborCount, currentColor);
            minCost = Math.Min(minCost, currentCost); //NOTE
        }
        else
        {
            int totalColors = cost[0].Length;//
            for (int c = 1; c <=totalColors; c++)
            {
                currentColor = c;
                //neighborCount += (prevColor == currentColor) ? 0 : 1;
                int newNeighborCount = neighborCount + (prevColor == currentColor ? 0 : 1);
                //NOTE: currentColor - 1
                int currentCost = cost[houseIndex][currentColor - 1]
                             + FindMinCost (houses, cost, target, houseIndex + 1, newNeighborCount, currentColor);
                minCost = Math.Min(minCost, currentCost);
            }
        }
        
        memo[houseIndex, neighborCount, prevColor] = minCost;
        return minCost;
    }
    
//     private bool NeighborhoodCountMatchesTarget(int[] houses, int target)
//     {
//         int neighborCount = 1;        
//         for (int i = 1; i < houses.Length; i++)
//         {
//             if(houses[i] != houses[i - 1])
//             {
//                 neighborCount++;
//             }
//         }
        
//         return neighborCount == target;
//     }
}

public class Solution2
{
    /// Time complexity, O(T * M * N^2)
    /// Space complexity, can be reduced from O(T * M * N) to O(M * N)
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
    {
        //initial color starts from 1
        var initialColor = 1;
        //max value for the initialization. Can't put int.MAXVALUE since it might overflow.
        int max = (int)(1e6 + 1);

        //DP[k][i][c], minimal cost to form k neighbors with first i houses and end with color c. 
        //all boundary plus 1 for padding
        //var DP = new int[target + 1][][];
        var dp = new int[target + 1, houses.Length + 1, n + 1];
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                for (int k = 0; k < dp.GetLength(2); k++)
                {
                    if (i == 0 && j == 0)
                        //initialize 0 when neighbor = 0 and house = 0
                        dp[i,j,k] = 0;
                    else
                        dp[i,j,k] = max;

                }
            }
        }
        
        for (int k = 1; k <= target; k++)
        {
            for (int i = k; i <= m; i++)
            {
                var currHouseColor = houses[i - 1];
                var prevHouseColor = i >= 2 ? houses[i - 2] : 0;
                // check if the house has been painted, if no (currHouseColor = 0), set 1 to n to scan
                Tuple<int, int> curr = currHouseColor > 0 ? new Tuple<int, int>(currHouseColor, currHouseColor) : new Tuple<int, int>(initialColor, n);
                Tuple<int, int> prev = prevHouseColor > 0 ? new Tuple<int, int>(prevHouseColor, prevHouseColor) : new Tuple<int, int>(initialColor, n);

                //scan the color one step each
                for (int ci = curr.Item1; ci <= curr.Item2; ci++)
                {
                    //cost to paint. If has been painted, the cost is 0, otherwise to fetch the cost
                    int currCost = ci == currHouseColor ? 0 : cost[i - 1][ci - 1];
                    for (int cj = prev.Item1; cj <= prev.Item2; cj++)
                    {
                        dp[k,i,ci] = Math.Min(dp[k,i,ci], dp[k - (ci != cj ? 1 : 0),i - 1,cj] + currCost);
                    }
                }
            }
        }

        int ans = max;

        for (int i = 0; i < dp.GetLength(2); i++)
        {
            ans = Math.Min(ans, dp[target,m,i]);
        }

        return ans >= max ? -1 : ans;
    }
}
