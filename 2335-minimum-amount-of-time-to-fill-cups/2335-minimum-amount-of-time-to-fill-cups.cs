//Using  priority_queue: https://leetcode.com/problems/minimum-amount-of-time-to-fill-cups/discuss/2277595/c%2B%2B-or-simple-solution

//It's a brain-teaser.
//The possible strategy is greedily fill up 2 cups with different types of water.
//We pick the 2 types with the most number of cups.

public class Solution {
    //https://leetcode.com/problems/minimum-amount-of-time-to-fill-cups/discuss/2261394/JavaC%2B%2BPython-max(max(A)-(sum(A)-%2B-1)-2)
    public int FillCups(int[] amount) {
        int max = 0;
        int sum = 0;
        
        foreach (int a in amount)
        {
            max = Math.Max(a, max);
            sum += a;
        }        
              
        return Math.Max(max, (sum + 1)/2);//taking ceiling of sum/2; because if odd number, we need 1 extra step
    }
}


public class Solution3 {
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