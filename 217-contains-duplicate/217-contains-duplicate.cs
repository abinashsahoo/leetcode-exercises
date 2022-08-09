// Questions: Can we modify (sort) the input list?
public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        Array.Sort(nums);
        int? prevNumber = null;
        for (int i = 0; i < nums.Length; i++)
        {
            if (prevNumber == nums[i]) // Nullable int quelity with int
            {
                return true;                
            }
            prevNumber = nums[i];
        }
        return false;
    }
}