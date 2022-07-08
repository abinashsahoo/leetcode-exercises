public class Solution {
    
    int[,,] memo = null;
    const int MaxCost = (int)1e6 + 1;//Maximum cost possible plus 1
    
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target) 
    {   
        memo = new int[houses.Length, n + 1, houses.Length];
        var result = FindMinCost (houses, cost, target, 0, 0, 0);
        return result == MaxCost ? -1 : result;
    }
    
    private int FindMinCost (int[] houses, int[][] cost, int target, int houseIndex, int prevColor, int neighborCount)
    {
        if(houseIndex == houses.Length)// not houses.Length - 1
        {
            return neighborCount == target ? 0 : MaxCost;
        }
        
        if(neighborCount > target)//No need to calculate further!
        {
            return MaxCost;
        }        
        
        if(memo[houseIndex, prevColor, neighborCount] != 0)
        {            
            return memo[houseIndex, prevColor, neighborCount];
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
            int currentCost = FindMinCost (houses, cost, target, houseIndex + 1, currentColor, newNeighborCount);
            minCost = Math.Min(minCost, currentCost);
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
                             + FindMinCost (houses, cost, target, houseIndex + 1, currentColor, newNeighborCount);
            
                minCost = Math.Min(minCost, currentCost);
            }
        }
        
        memo[houseIndex, prevColor, neighborCount] = minCost;
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