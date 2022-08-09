// Questions: Can we modify (sort) the input list?
public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        Array.Sort(nums); //If Quicksort  is used, space complexity would be O(logN)
        int? prevNumber = null;
        for (int i = 0; i < nums.Length; i++)
        {
            if (prevNumber == nums[i]) // Nullable int equality with int
            {
                return true;                
            }
            prevNumber = nums[i];
        }
        return false;
    }
}