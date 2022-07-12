// [5,5,5,5,4] -> Only sum % 4 won't work: matchsticks.Sum() % 4 == 0
public class Solution {
    private bool _isSquare = false;
    private int _side;
    
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
        
        _side = perimeter/4;
        
        //Extra validation can be added
        if (matchsticks.Any(num => num > _side))
        {
            return false;
        }
        
        //NOTE: Got TLE without Sort
        //Reverse sort the matchsticks because we want to consider the biggest one first.
       //Array.Sort(matchsticks, (a, b) => b.CompareTo(a));
        Array.Sort(matchsticks, (a, b) => b - a);
        
        //This array represents the 4 sides and their current lengths
        int[] sums = new int[4];
        
        Dfs(matchsticks, 0, sums);
        
        return _isSquare;
    }
    
    private void Dfs(int[] matchsticks, int index, int[] sums)
    {
        if (index == matchsticks.Length)
        {
            //return sums[0] == sums[1] && sums[1] == sums[2] && sums[2] == sums[3];
            _isSquare = sums.All(s => s == _side);
        }
        
        if(_isSquare) return;

        int element = matchsticks[index];
        //Try adding it to each of the 4 sides (if possible)
        for (int i = 0; i < 4; i++)
        {
            //If this matchstick can fit in the space left for the current side
            if(sums[i] + element <= _side)
            {
                sums[i] += element;
                Dfs(matchsticks, index + 1, sums);
                //Revert the effects of recursion because we no longer need them for other recursions.
                sums[i] -= element;
            }
        }
    }
}