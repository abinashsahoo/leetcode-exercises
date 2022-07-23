public class Solution {
    public IList<int> CountSmaller(int[] nums) {
        var result = new int[nums.Length];
        var sortedNums = new List<int>();
        
        for(int i = nums.Length - 1; i >= 0; i--)
        {
            int left = 0;
            int right = sortedNums.Count;
            
            while(left < right)
            {
                var mid = left + (right - left) / 2;
                if(sortedNums[mid] >= nums[i])
                    right = mid;
                else
                    left = mid + 1;
            }
            
            result[i] = left;
            sortedNums.Insert(left, nums[i]);
        }
        
        return result;
    }
}

public class Solution2 {
    public IList<int> CountSmaller(int[] nums) {
        return nums.Select((n, i) => nums[(i + 1)..].Count(n => n < nums[i])).ToList();
    }
}

public class Solution1 {
    public IList<int> CountSmaller(int[] nums) {
        var result = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int count = 0;
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] < nums[i])
                    count++;
            }
            result.Add(count);
        }
        return result;
    }
}