public class Solution {
    public void NextPermutation(int[] nums) {
       
        int i = LastPeakIndex(nums);
        int pivot = i - 1;
       
        if(pivot >= 0)
        {
            int j = RightMostSuccessor(nums, pivot); 
            Swap(nums, pivot, j);
        }
        
        Reverse(nums, i);         
    }    

    private int LastPeakIndex(int[] nums)
    {
        int i = nums.Length - 1;
        while(i > 0 && nums[i] <= nums[i-1])
        {
            i--;
        }
        return i;
    }
    
    private int RightMostSuccessor(int[] nums, int index)
    {
        int i = nums.Length - 1;
        while(nums[i] <= nums[index])
            i--;
        
        return i;            
    }
    
    private void Reverse(int[] nums, int start) 
    {
        int i = start, j = nums.Length - 1;
        while (i < j) 
        {
            Swap(nums, i, j);
            i++;
            j--;
        }
    }
    
    private void Swap(int[] nums, int i, int j) 
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}