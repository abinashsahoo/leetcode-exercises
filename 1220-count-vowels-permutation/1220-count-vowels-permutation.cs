public class Solution 
{
     /*
        a = 0,
        e = 1,
        i = 2,
        o = 3,
        u = 4
    */
    public int CountVowelPermutation(int n) 
    {
        long mod = 1_000_000_007;
        var count = new long[5]{1, 1, 1, 1, 1}; 
        for(int i = 2; i <= n; i++)
        {
            var countTemp = new long[5];
            countTemp[0] = count[1] + count[2] + count[4];
            countTemp[1] = (count[0] + count[2]) % mod;
            countTemp[2] = (count[1] + count[3]) % mod;
            countTemp[3] = count[2];
            countTemp[4] = (count[2] + count[3]) % mod;
            count = countTemp;
            // countTemp[0] = count[1];
            // countTemp[1] = (count[0] + count[2]) % mod;
            // countTemp[2] = (count[0] + count[1] + count[3] + count[4]) % mod;
            // countTemp[3] = (count[2] + count[4]) % mod;
            // countTemp[4] = count[0];
            // count = countTemp;
        }
        
        return (int) (count.Sum() % mod);
    }
}

public class Solution1 { 
    public int CountVowelPermutation(int n) {
        
        const int MOD = (int)1e9 + 7;
        
        long aCount = 1;
        long eCount = 1;
        long iCount = 1;
        long oCount = 1;
        long uCount = 1;
        
        for (int i = 1; i < n; i++)
        {
            long aCountNew = (eCount + iCount + uCount) % MOD;
            long eCountNew = (aCount + iCount) % MOD;
            long iCountNew = (eCount + oCount) % MOD;
            long oCountNew = iCount % MOD;
            long uCountNew = (iCount + oCount) % MOD;
            
            aCount = aCountNew;
            eCount = eCountNew;
            iCount = iCountNew;
            oCount = oCountNew;
            uCount = uCountNew;
        }
        
        long result = (aCount + eCount + iCount + oCount + uCount) % MOD;
        return (int) result;
    }
}