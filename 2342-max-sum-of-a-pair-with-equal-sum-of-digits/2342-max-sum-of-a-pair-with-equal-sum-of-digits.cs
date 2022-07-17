public class Solution {
    public int MaximumSum(int[] nums) 
    {
        var map = new int[9 * 9 + 1];// new int[82];//max input 10^9; max sum of digits 9*9 (999999999) = 81        
        int maxSum = -1;
        foreach(var num in nums)
        {
            int digitSum = DigitSum(num);
            if(map[digitSum] > 0)
            {
                maxSum = Math.Max(maxSum, map[digitSum] + num);
                map[digitSum] = Math.Max(map[digitSum], num);
            }
            else
            {
                map[digitSum] = num;
            }
        }        
        return maxSum;
    }
    
    private int DigitSum(int num)
    {
        int sum = 0;
        for (int n = num; n > 0; n /= 10)
        {
            sum += n % 10;
        }
        return sum;
    }

    private int DigitSum1(int num) 
    {
        return num.ToString().Sum(c => c - '0');
    }
}

public class Solution1 {
    public int MaximumSum(int[] nums) 
    {
        var dictionary = new Dictionary<int, List<int>>();
        foreach(var num in nums)
        {
            int digitSum = DigitSum(num);
            if(dictionary.ContainsKey(digitSum))
            {
                dictionary[digitSum].Add(num);
            }
            else
            {
                dictionary.Add(digitSum, new List<int>(new int[] { num }));
            }
        }
        
        int maxSum = -1;
        foreach(var kv in dictionary.Where(kv => kv.Value.Count >= 2))
        {
            int max1 = 0;
            int max2 = 0;
            foreach(int val in kv.Value)
            {
                if (val > max1)
                {
                    max2 = max1;
                    max1 = val;
                }
                else if (val > max2)
                {
                    max2 = val;
                }
            }
            maxSum = Math.Max(max1 + max2, maxSum);
        }
        return maxSum;
    }
    
    private int DigitSum(int num) 
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num = num/10;
        }
        return sum;
    }

    private int DigitSum1(int num) 
    {
        return num.ToString().Sum(c => c - '0');
    }
}