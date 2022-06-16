public class Solution {
    public int FindMin(int[] nums) {
        int left = 1;
        int right = nums.Length - 1;
        
        while(left <= right)
        {
            int mid = left + (right - left)/2;            
            if(nums[mid] < nums[mid - 1])
            {
                return nums[mid];
            }
            else if (nums[mid] > nums[mid - 1] && nums[mid] > nums[0])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        
        return nums[0];
    }
}