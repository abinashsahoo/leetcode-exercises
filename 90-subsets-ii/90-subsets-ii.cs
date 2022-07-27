public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums); // This would generate sorted subset and would help in determining duplicates
        
        var result = new List<IList<int>>();
        var seen = new HashSet<string>();
        int n = nums.Length;
        int maxNumOfSubsets = (int)Math.Pow(2, n);
        
        for (int i = 0; i < maxNumOfSubsets; i++)
        {
            var newSubset = new List<int>();
            var subSetAsString = new StringBuilder();
            for (int j = 0; j < n; j++)
            {
                var mask = 1 << j;
                var isSet = mask & i;
                if(isSet > 0)
                {
                    newSubset.Add(nums[j]);
                    subSetAsString.Append(nums[j]);
                }
            }
            
            var subSetString = subSetAsString.ToString();
            if(!seen.Contains(subSetString))
            {
                result.Add(newSubset);
                seen.Add(subSetString);
            }
        }
        return result;
    }
}