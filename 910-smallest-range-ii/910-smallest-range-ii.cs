//[7,8,8], k = 5
public class Solution {
    public int SmallestRangeII(int[] nums, int k) {                      
        
        if(nums.Length == 1) return 0;
        
        Array.Sort(nums);
        
        int result = nums[nums.Length - 1] - nums[0];       
        for(int i=0; i< nums.Length - 1; i++)
        {
            int min = Math.Min(nums[0]+k, nums[i+1]-k);
            int max = Math.Max(nums[i]+k, nums[nums.Length - 1] - k);
            
            result = Math.Min(result, max - min);
        }
        
        return result;
    }
}