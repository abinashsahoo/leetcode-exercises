public class Solution {
    public int[][] DiagonalSort(int[][] mat) {
        var map = new Dictionary<int, List<int>>();		// key= i-j and value is all the values in that diagonal;
        
        for(int i=0; i < mat.Length; i++) {				// Just add everything to the map;
            for(int j=0; j < mat[0].Length; j++) {                
                var key = i-j;
                if(!map.ContainsKey(key))
                {
                    map.Add(key, new List<int>());                    
                }
                map[key].Add(mat[i][j]);
            }
        }
        
        foreach(var key in map.Keys) // Since we dont have priority queue in c#, just sort individual rows
            map[key].Sort();
        
        for(int i=0; i<mat.Length; i++) 
        {
            // Pick the first element from the list and remove that element;
            for(int j=0; j < mat[0].Length; j++) 
            {                
                var val = map[i-j][0];
				mat[i][j] = val;
                map[i-j].RemoveAt(0);
            }
        }
        
        return mat;
    }
}