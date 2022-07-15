public class Solution {
    public IList<int> ShortestDistanceColor(int[] colors, int[][] queries) {
        var result = new List<int>();
        //var set = new Dictionary<int, SortedSet<int>>();
        var set = new Dictionary<int, List<int>>(); //Indexes will be sorted by default
        
        for (int i = 0; i < colors.Length; i++)
        {
            if (!set.ContainsKey(colors[i]))
            {
                set.Add(colors[i], new List<int>());
            }
            
            set[colors[i]].Add(i);
        }
        
        foreach (var arr in queries)
        {
            int i = arr[0];
            int c = arr[1];
            
            if(colors[i] == c)
            {
                result.Add(0);
            }
            else if(set.ContainsKey(c))
            {
                result.Add(SearchColor(set[c], i));
            }
            else
            {
                result.Add(-1);
            }
        }
        
        return result;
    }
    
    private int SearchColor(List<int> sortedList, int i)
    {
        if (i < sortedList[0]) 
            return sortedList[0] - i;
        if (i > sortedList[^1]) 
            return i - sortedList[^1];
        
        int result = sortedList.BinarySearch(i);
        if(result < 0)
        {
            result = ~result;
            return Math.Min(sortedList[result] - i, i - sortedList[result - 1]);
        }
        
        return -1;
    }
}