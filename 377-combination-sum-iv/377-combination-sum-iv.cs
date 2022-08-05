//Question: Does the order of elements in the combination matter?
public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        int answer = 0;
        var memo = new Dictionary<int, int>();
        return CombinationSum4(nums, target, memo);
    }
    
    private int CombinationSum4(int[] nums, int target, Dictionary<int, int> memo) {
        if (target == 0)
        {
            return 1;
        }
        
        if (memo.ContainsKey(target))
        {
            return memo[target];
        }
        
        int result = 0;
        foreach (int num in nums)
        {
            if (target - num >=0) //NOTE: >=
            {
                result += CombinationSum4(nums, target - num, memo);
            }
            // else
            // {
            //     break; //NOTE: If nums sorted we could break here
            // }
        }
        
        memo.Add(target, result);
        return result;
    }
}

// Incorrect. I thought I need to use 1 number only once
public class Solution1 {
    public int CombinationSum4(int[] nums, int target) {
        int answer = 0;
        int n = nums.Length;
        int limit = (int)Math.Pow(2, n);
        for (int i = 1; i < limit; i++)
        {
            int flag = 1;
            int sum = 0;
             Console.Write("Indices: ");
            for (int j = 0; j < n; j++)
            {
                if ((i & flag) > 0) // (i & flag) () needs to be used
                {
                    Console.Write($"{j} -> ");
                    sum += nums[j];
                }
                flag = flag << 1;
                //Console.WriteLine("---");
            }
            Console.WriteLine($"Sum: {sum}");
            if (sum == target)
            {
                answer++;                
            }
        }
        return answer;
    }
}