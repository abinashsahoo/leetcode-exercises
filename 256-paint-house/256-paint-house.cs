public class Solution {
    
    private Dictionary<(int, int), int> cache = new();
    
    public int MinCost(int[][] costs) {
        
        if (costs.Length == 0)
        {
            return 0;
        }
        
        return Enumerable.Range(0, 3)//generates 0, 1, 2
                .Min(c => MinCost(costs, 0, c));
    }

    private int MinCost(int[][] costs, int houseIndex, int color) 
    {
        if(cache.ContainsKey((houseIndex, color)))
        {
            return cache[(houseIndex, color)];
        }
        
        if (houseIndex == costs.Length - 1)
        {
            return costs[houseIndex][color];
        }
                
        int totalCost = costs[houseIndex][color] + Enumerable.Range(0, 3)
                .Where(c => c != color)//Except color of current house
                .Min(c => MinCost(costs, houseIndex + 1, c));
        cache.Add((houseIndex, color), totalCost);
        
        return totalCost;
    }
}