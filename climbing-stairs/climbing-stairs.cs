public class Solution {
    public int ClimbStairs(int n) {
        if(n < 1 || n > 45) 
            throw new ArgumentOutOfRangeException(nameof(n));
        
        if(n == 1) return 1;//If remove this line, loop'd be starting from 1
        
        int waysToPreviousStep = 1;
        int waysTopreviousToPreviousStep = 1;
        int noOfWays = 0;//
        for(int step = 2; step <= n; step++)
        {
            noOfWays = waysToPreviousStep + waysTopreviousToPreviousStep;
            waysTopreviousToPreviousStep = waysToPreviousStep;
            waysToPreviousStep = noOfWays;
        }
        
        return noOfWays;
    }
}