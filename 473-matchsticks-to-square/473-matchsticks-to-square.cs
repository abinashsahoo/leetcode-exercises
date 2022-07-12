// [5,5,5,5,4] -> Only sum % 4 won't work: matchsticks.Sum() % 4 == 0
public class Solution {
    public bool Makesquare(int[] matchsticks) {
        if (matchsticks == null || matchsticks.Length == 0)
        {
            return false;
        }
        
        int perimeter = matchsticks.Sum();
        if(perimeter % 4 != 0)
        {
            return false;
        }
        
        int side = perimeter/4;
        
        //Reverse sort the matchsticks because we want to consider the biggest one first.
        Array.Sort(matchsticks, (a, b) => b.CompareTo(a));
        
        //This array represents the 4 sides and their current lengths
        int[] sums = new int[4];
        
        return Dfs(0);
        
        bool Dfs(int index)
        {
            if (index == matchsticks.Length)
            {
                return sums[0] == sums[1] && sums[1] == sums[2] && sums[2] == sums[3];
            }
            
            int element = matchsticks[index];
            //Try adding it to each of the 4 sides (if possible)
            for (int i = 0; i < 4; i++)
            {
                //If this matchstick can fit in the space left for the current side
                if(sums[i] + element <= side)
                {
                    sums[i] += element;
                    if(Dfs(index + 1))
                    {
                        return true;
                    }
                    
                    //Revert the effects of recursion because we no longer need them for other recursions.
                    sums[i] -= element;
                }
            }
            
            return false;
        }
    }
}