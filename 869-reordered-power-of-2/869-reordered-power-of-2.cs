public class Solution {
    public bool ReorderedPowerOf2(int n) {
        var num = GetSortedDigits(n).ToArray();
        
        for (int i = 0; i < 30; i++)
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