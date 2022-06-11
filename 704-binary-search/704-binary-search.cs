//Time complexity : O(logN)
//Space complexity : O(1)

//https://ai.googleblog.com/2006/06/extra-extra-read-all-about-it-nearly.html
//middle = (left + right) >> 1;
//Right shifting binary numbers would divide a number by 2 and left shifting the numbers would multiply it by 2. 
//middle = (left + right)/2;

public class Solution {
    public int Search(int[] nums, int target) {
        int middle, left = 0;
        int right = nums.Length - 1;
        
        while(left <= right)
        {            
            middle = left + (right - left) / 2; 
            
            if(nums[middle] == target) return middle;
            if(nums[middle] < target) left = middle + 1;
            if(nums[middle] > target) right = middle - 1;
        }
        
        return -1;        
    }
}