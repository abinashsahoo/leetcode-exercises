public class Solution {
    public bool ReorderedPowerOf2(int n) {
        var num = GetSortedDigits(n).ToArray();
        
        //n <= 10^9, we only need to check powers in the range [0,29]
        
        //for (int i = 0; i < 30; i++)
        for (int i = 0; i <= (int)Math.Log2(1e9); i++)
        {
            var powerOfTwo = GetSortedDigits(1 << i);            
            if(powerOfTwo.SequenceEqual(num))
                return true;
        }
        return false;
    }
    
    private IEnumerable<char> GetSortedDigits(int num)
    {
        return num.ToString().ToCharArray()
                 .OrderBy(c => c);
    }
} 