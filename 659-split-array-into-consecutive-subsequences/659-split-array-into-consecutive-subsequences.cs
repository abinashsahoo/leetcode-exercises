public class Solution {
    public bool IsPossible(int[] nums) {
        var freqMap = new Dictionary<int, int>();
        var hypoMap = new Dictionary<int, int>();
        foreach (int n in nums)
        {
            freqMap[n] = freqMap.ContainsKey(n) ? freqMap[n] + 1 : 1;
        }
        
        foreach (int n in nums)
        {
            if (freqMap[n] == 0) continue;//Number has already been used
            
            if (HasKey(hypoMap, n))// This check comes first? TC: [1,2,3,4,5,5,6,7]
            {
                hypoMap[n]--;
                freqMap[n]--;
                hypoMap[n + 1] = hypoMap.ContainsKey(n + 1) ? hypoMap[n + 1] + 1 : 1;
            }       
            //need to create a new sequence of 3, if it is not possible return false;
            else if (HasKey(freqMap, n + 1) && HasKey(freqMap, n + 2))
            {
                freqMap[n]--;
                freqMap[n + 1]--;
                freqMap[n + 2]--;
                    
                hypoMap[n + 3] = hypoMap.ContainsKey(n + 3) ? hypoMap[n + 3] + 1 : 1;
            }    
            else
            {
                return false;
            }
        }
        return true;
    }
    
    public bool HasKey(Dictionary<int,int> map, int key)
    {
        return map.ContainsKey(key) && map[key] > 0;
    }
    
}