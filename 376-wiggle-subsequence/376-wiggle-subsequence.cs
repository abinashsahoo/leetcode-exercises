//[3,3,3,2]
//[3,3]
public class Solution {
    public int WiggleMaxLength(int[] nums) {
        if(nums.Length <= 1)
        {
            return nums.Length;
        }        
        
        int prevDiff = nums[1] - nums[0];
        int sequenceLength = prevDiff != 0 ? 2 : 1;
        for (int i = 2; i < nums.Length; i++)
        {
            int diff = nums[i] - nums[i - 1];
            if (prevDiff >= 0 && diff < 0)
            {
                sequenceLength++;
                prevDiff = diff;
            }
            else if (prevDiff <= 0 && diff > 0)
            {
                sequenceLength++;
                prevDiff = diff;
            }
            // else //prevDiff,diff > 0; prevDiff,diff < 0; prevDiff,diff = 0
            // {
            //     prevDiff += diff;
            // }                      
            
            
        }
        
        return sequenceLength;
    }
}