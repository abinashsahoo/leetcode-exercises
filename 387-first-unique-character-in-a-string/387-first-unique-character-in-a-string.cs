//Space complexity : O(1) because English alphabet contains 26 letters.

//Space complexity : O(1) because English alphabet contains 26 letters.
public class Solution {
    public int FirstUniqChar(string s) {        
        Dictionary<char, int> set = new();
        foreach (char c in s)
        {
            set[c] = set.ContainsKey(c) ? set[c] + 1 : 1;
        }
        
        for (int i = 0; i < s.Length; i++)
        {
            if(set[s[i]] == 1)
                return i;
        }
        return -1;
    }
}

public class Solution1 {
    public int FirstUniqChar(string s) {        
        Dictionary<char, (int, int)> set = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (!set.ContainsKey(s[i]))
            {
                set.Add(s[i], (i, 1));
            }
            else
            {
                var (index, count) = set[s[i]];
                set[s[i]] = (index, count + 1);
            }
        }
        
        int result = int.MaxValue;
        foreach (var (index, count) in set.Values)
        {
            if(count == 1 && result > index)
                result = index;
        }
        return result == int.MaxValue ? -1 : result;
    }
}