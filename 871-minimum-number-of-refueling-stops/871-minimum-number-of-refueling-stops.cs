public class Solution {
    public int MinRefuelStops(int target, int startFuel, int[][] stations) {
        SortedSet<(int, int)> set = new();
        int stops = 0, i = 0;
        
        while(startFuel < target)
        {
            while(i < stations.Length && stations[i][0] <= startFuel)
            {
                set.Add((stations[i][1], i++));
            }
            if(set.Count == 0)
                return -1;
                
            startFuel += (set.Max().Item1); // You can still access as Item1
            set.Remove(set.Max());
            stops++;
        }
        
        return stops;
    }
}