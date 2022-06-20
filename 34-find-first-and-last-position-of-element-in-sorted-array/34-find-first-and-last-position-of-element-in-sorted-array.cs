public class Solution {
    public int[] SearchRange(int[] nums, int target) {
                
        int left = 0;
        int right = nums.Length - 1;
        var result = new int[2];
        Array.Fill(result, -1);
        
        if(!nums.Any()) return result;
        
        while ( left <= right)
        {
            int mid = left + (right - left)/2;
            if(nums[mid] == target)
            {
                if(mid == left || nums[mid - 1] < target)
                {
                    result[0] = mid;
                    break;
                }
                
                right = mid - 1;
            }
            else if(nums[mid] < target)
            {                
                left = mid + 1;
            }
            else if(nums[mid] > target)
            {
                right = mid - 1;
            }
        }
        
        left = 0;
        right = nums.Length - 1;
        
        while ( left <= right)
        {
            int mid = left + (right - left)/2;            
            if(nums[mid] == target)
            {
                if(mid == right || nums[mid + 1] > target)
                {
                    result[1] = mid;
                    break;
                }
                
                left = mid + 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
                
        }
        
        return result;
    }
}