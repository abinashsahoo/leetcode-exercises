//[0,3,7,2,5,8,4,6,0,1] -> what if equals; When all numbers are part of subsequence
//[9,1,4,7,3,-1,0,5,8,-1,6]
public class Solution {

        public int LongestConsecutive(int[] nums) {
        if(nums.Length <= 1) return nums.Length;
        
        var set = new HashSet<int>(nums); //O(1)
        
        int longestStreak = 0;
        int currentStreak = 0;
        
        foreach (int num in set)//Index can't be used for HashSet; so use foreach
        {
            if(!set.Contains(num - 1)) //If set.Contains(num - 1), num is a part of longer subsequence, skip it for now
            {
                currentStreak = 1;
                int i = 1;
                while (set.Contains(num + i))
                {
                    currentStreak++;
                    i++;
                }
                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }
        return Math.Max(longestStreak, currentStreak); //important When all numbers are part of subsequence
    }
    
    public int LongestConsecutive1(int[] nums) {
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
                longestStreak = Math.Max(longestStreak, currentStreak);
                currentStreak = 1;
                //i++; //for loop is going to increase it anyway
            }
        }
        return Math.Max(longestStreak, currentStreak); //important When all numbers are part of subsequence
    }
}