
public class Solution {
    
    // Monotonic increasing queue; Deque replacement
    public int MaxResult(int[] nums, int k)
    {
        int[] scores = new int[nums.Length];
        scores[0] = nums[0];
        LinkedList<int> q = new LinkedList<int>();
        q.AddLast(0);

        for (int i = 1; i < nums.Length; i++)
        {
            // pop the old index
            while (i - q.First.Value > k)
            {
                q.RemoveFirst();
            }

            scores[i] = scores[q.First.Value] + nums[i];

            while (q.Count > 0 && scores[i] >= scores[q.Last.Value])
            {
                q.RemoveLast();
            }

            q.AddLast(i);
        }

        return scores[nums.Length - 1];
    }
    
    //Deque Replacement
    public int MaxResultDeque(int[] nums, int k) 
    {
        if (nums.Length == 0) return 0;
        
        var q = new List<int>();
        int len = nums.Length, sum = 0;
        var dp = new int[len];
        
        int i = 0;
        while(i < len) {
            while(q.Count > 0 && i - q[0] > k) q.RemoveAt(0);
            
            int n = nums[i];
            dp[i] = q.Count == 0 ? n : dp[q[0]] + n;
            while(q.Count > 0 && dp[q[q.Count - 1]] < dp[i]) q.RemoveAt(q.Count - 1);
            
            q.Add(i++);
        }
        
        return dp[len - 1];
    }
    
    //bottom Up DP - TLE
    public int MaxResultDP1(int[] nums, int k)  
    {
        int[] dp = new int[nums.Length];
        Array.Fill(dp, int.MinValue);
        dp[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 1; j <= k && i - j >= 0; j++)
            {
                dp[i] = Math.Max(dp[i], dp[i - j] + nums[i]);
            }
        }
        
        return dp[^1];
    }  
    
    //Recursive - TLE
    public int MaxResultRecursive(int[] nums, int k)  
    {
        return MaxResult(nums, k, 0);
    }       
    
    private int MaxResult(int[] nums, int k, int i) 
    {
        if( i >= nums.Length - 1) return nums[^1];
        
        int max = int.MinValue;
        for (int j = 1; j <= k; j++) 
        {
            int sum = nums[i] + MaxResult(nums, k, i + j);
            max = Math.Max(max, sum);
        }
        
        return max;
    }
    
    //Greedy not working
    //e.g., [0,-1,-2,-3,1], k = 2
    public int MaxResult1(int[] nums, int k) {
        
        int sum = nums[0];
        int i = 0;
        while (i < nums.Length)
        {
            //Get the max within i + k
            int max = int.MinValue;
            int maxIndex = Math.Min(i + k, nums.Length - 1);//NOTE
            int step = maxIndex;
            while (i < step)
            {
                if(nums[step] > max)
                {
                    max = nums[step];
                    maxIndex = step;
                }
                step--;
            }
            
            sum += max == int.MinValue ? 0 : max;
            i = max == int.MinValue ? maxIndex + 1 : maxIndex;// maxIndex is the new i
        }
        
        return sum;
    }
}