// Is the tocken list in sorted order? 
public class Solution {
    public int BagOfTokensScore(int[] tokens, int power) {
        //Face Up -> Play with smallest valued token -> loose least power
        //Face Down -> play with largest valued token -> gain most power but loosing same score        
        //Play Face Up until I can, then play 1 token Face Down to score power
        
        Array.Sort(tokens);
        
        int lo = 0, hi = tokens.Length - 1;
        int maxScore = 0, score = 0;
        
        while (lo <= hi && (power >= tokens[lo] || score > 0))
        {
            while (lo <= hi && power >= tokens[lo])
            {
                power -= tokens[lo];
                score++;
                lo++;
            }
            
            maxScore = Math.Max(maxScore, score);
            if (score > 0)
            {
                power += tokens[hi];
                hi--;
                score--;
            }
        }
        return maxScore;
    }
}