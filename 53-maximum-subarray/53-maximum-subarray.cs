public class Solution {
    
        public int MaxSubArray(int[] nums) {            
            int maxSubArray = nums[0]; 
            int currentSubArray = nums[0];
            
            for(int i = 1; i < nums.Length; i++)
            {
                //currentSubArray = Math.Max(currentSubArray, currentSubArray + nums[i]);
                currentSubArray =  nums[i] + (currentSubArray > 0 ? currentSubArray : 0);
                maxSubArray = Math.Max(maxSubArray, currentSubArray);
            }
        
        return maxSubArray;
    }
    
//     public int MaxSubArray(int[] nums) {
//         int maxSubArray = int.MinValue;        
//         for(int i = 0; i < nums.Length; i++)
//         {
//             int currentSubArray = 0;
//             for (int j = i; j < nums.Length; j++)
//             {
//                 currentSubArray += nums[j];
//                 maxSubArray = Math.Max(maxSubArray, currentSubArray);
//             }
//         }
        
//         return maxSubArray;
//     }
}