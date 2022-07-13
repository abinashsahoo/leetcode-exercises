public class Solution {
    public int FillCups(int[] amount) {
        var sorted = amount.OrderByDescending(a => a).ToArray();
        int result = 0;
        while (sorted[1] > 0)
        {
            result++;
            sorted[0]--;
            sorted[1]--;
            
            Array.Sort(sorted, (a, b) => b - a);
        }
        
        result += sorted[0];
        
        return result;
    }
}

public class Solution1 {
    public int FillCups(int[] amount) {
        var sorted = amount.OrderByDescending(a => a).ToArray();
        
        int result = 0;
        for (int i = 0; i < sorted.Length; i++)
        {
            int count = sorted[i];
            int j = i + 1;
            while (count > 0)
            {
                result++;
                count--;
                if(j < sorted.Length && sorted[j] > 0)
                {
                    sorted[j]--;
                    j = (j + 1 < sorted.Length && sorted[j + 1] > 0) ? j + 1 : i + 1;
                }
            }
        }
        
        return result;
    }
}