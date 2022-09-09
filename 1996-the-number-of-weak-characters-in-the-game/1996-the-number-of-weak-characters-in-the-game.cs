public class Solution {
    public int NumberOfWeakCharacters(int[][] properties) {
        int weakCount = 0;
        
        // Sort in descending order of attack, 
        // If attack is same sort in ascending order of defense
        Array.Sort(properties, (x, y) => (x[0] == y[0]) ? x[1] - y[1] : y[0] - x[0]);
        
        int maxDefense = 0;
        for (int i = 0; i < properties.Length; i++)
        {
            // Compare the current defense with the maximum achieved so far
            if (properties[i][1] < maxDefense)
            {
                weakCount++;
            }
            
            if (properties[i][1] > maxDefense)
            {
                maxDefense = properties[i][1];
            }
        }
        return weakCount;
    }
}

// brute force, O(N^2) - TLE
public class Solution1 {
    public int NumberOfWeakCharacters(int[][] properties) {
        int weakCount = 0;
        for (int i = 0; i < properties.Length; i++)
        {
            for (int j = 0; j < properties.Length; j++)
            {
                if (properties[j][0] > properties[i][0] && properties[j][1] > properties[i][1])
                {
                    weakCount++;
                    break; // Important
                }
            }
        }
        return weakCount;
    }
}