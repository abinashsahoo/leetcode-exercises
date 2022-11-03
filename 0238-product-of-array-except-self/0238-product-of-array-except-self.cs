//What if the item is 0? [-1,1,0,-3,3]
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] result = new int[nums.Length];
        
        result[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];//Store the left products
        }
        
        int right = 1;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            right = right * nums[i + 1];
            result[i] = result[i] * right;//multiply with right product
        }        
        
        return result;
    }
}

//Time O(3N)
//Space: O(2N)
public class Solution1 {
    public int[] ProductExceptSelf(int[] nums) {
        int[] left = new int[nums.Length];
        int[] right = new int[nums.Length];
        
        left[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            left[i] = left[i - 1] * nums[i - 1];
        }
        
        right[nums.Length - 1] = 1;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            right[i] = right[i + 1] * nums[i + 1];
        }        
        
        return nums.Select((_, i) => left[i] * right[i]).ToArray();
    }
}