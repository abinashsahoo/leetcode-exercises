public class Solution {
    public int MinSetSize(int[] arr) {
        Dictionary<int, int> frequency = new();
        foreach(int a in arr)
        {
            frequency[a] = frequency.ContainsKey(a) ? frequency[a] + 1 : 1;
        }
        
        //int target = Math.Ceiling(arr.Length/2m);//m - decimal; d - double
        var result = 0;
        int countSum = 0;
        foreach (int count in frequency.Values.OrderByDescending(v => v))
        {
            countSum += count;
            result++;
            if (countSum >= arr.Length/2)
                break;
        }
        return result;
    }
}