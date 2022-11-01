public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        //Contract.Require(nums.Length >= 3, "Invaliid Array!");
        Array.Sort(nums);
        
        int diff = int.MaxValue;
        for (int i = 0; i < nums.Length - 2 && diff != 0; i++) //NOTE: diff != 0, if target already found
        {
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right) 
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (Math.Abs(target - sum) < Math.Abs(diff)) //Store real diff, so use Abs here
                {
                    diff = target - sum;//Store real, because finally return target - diff;
                }
                if (sum < target) 
                {
                    left++;
                } 
                else 
                {
                    right--;
                }
            }
        }
        return target - diff;//diff = target - sum;
    }
}

public class Solution1 {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        
        int closestSum = nums[0] + nums[1] + nums[2];
        for (int i = 0; i < nums.Length - 2; i++)
        {
            int sum =  TwoSum (nums, i, target);
            if (Math.Abs(closestSum - target) > Math.Abs(sum - target))
            {
               closestSum = sum;
            }
        }
        return closestSum;
    }
    
    private int TwoSum (int[] nums, int i, int target)
    {
        int left = i + 1, right = nums.Length - 1;
        int closestMin = nums[i] + nums[i + 1] + nums[i + 2];
        int closestMax = nums[^1] + nums[^2] + nums[^3];
        while (left < right)
        {
            int sum = nums[i] + nums[left] + nums[right];
            // if (sum == target)
            // {
            //     return sum;
            // }
            if (sum < target)
            {
                if (Math.Abs(closestMin - target) > Math.Abs(sum - target))
                {
                   closestMin = sum;
                }                
                left++;
            }
            else //(sum >= target)
            {
                if (Math.Abs(closestMax - target) > Math.Abs(sum - target))
                {
                   closestMax = sum;
                }                
                right--;
            }
        }
        if (Math.Abs(closestMin - target) > Math.Abs(closestMax - target))
        {
           return closestMax;
        }  
        else
            return closestMin;
    }
}