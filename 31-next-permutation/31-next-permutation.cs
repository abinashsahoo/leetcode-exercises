//1. Find the last peak in the sequence. In case two successive numbers are peak, return the first index
//2. Pivot is the element just before the the last peak
//3. If no such pivot exists, we are at the last permutation already. Just reverse the array and done.
//4. If pivot exists, swap the pivot with right most successor of the pivot.
//5. Reverse the sub-array starting at last peak index.

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

    //Start traversing from the end of the array and find an item which is greater that its left neighbour.
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