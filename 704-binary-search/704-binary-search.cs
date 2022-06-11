public class Solution {
    public int Search(int[] nums, int target) {
        int middle, left = 0;
        int right = nums.Length - 1;
        
        while(left <= right)
        {            
            middle = (left + right)/2;
            
            if(nums[middle] == target) return middle;
            if(nums[middle] < target) left = middle + 1;
            if(nums[middle] > target) right = middle - 1;
        }
        
        return -1;        
    }
}