//[0,3,7,2,5,8,4,6,0,1] -> what if equals; When all numbers are part of subsequence
//[9,1,4,7,3,-1,0,5,8,-1,6]
public class Solution {
    public int LongestConsecutive(int[] nums) {
        if(nums.Length <= 1) return nums.Length;
        
        Array.Sort(nums);
        
        int longestStreak = 1;
        int currentStreak = 1;
        
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] + 1 == nums[i])
            {
                currentStreak++;
            }
            else if (nums[i - 1] != nums[i])
            {
                Console.Write($"{currentStreak}-[{nums[i]}]->");
                longestStreak = Math.Max(longestStreak, currentStreak);
                currentStreak = 1;
                //i++;
            }
        }
        return Math.Max(longestStreak, currentStreak);
    }
}