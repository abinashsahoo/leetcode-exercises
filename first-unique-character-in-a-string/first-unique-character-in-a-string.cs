// Time Complexity: 26*O(n) complexity so we can considered O(n)
public class SolutionInteresting {
    public int FirstUniqChar(string s) {
        int result = int.MaxValue;
        for (char c = 'a'; c <= 'z'; c++)
        {
            int index = s.IndexOf(c);
            //index < result makes sure we are capturing the min(first) char
           if(index == s.LastIndexOf(c) && index > -1 && index < result) 
                result = index;
        }
        
        return result == int.MaxValue ? -1 : result;
    }
}

//Space complexity : O(1) because English alphabet contains 26 letters.
public class Solution {
    public int FirstUniqChar(string s) {        
        Dictionary<char, int> dict = new();
        foreach (char c in s)
        {
            dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
        }
        
        for (int i = 0; i < s.Length; i++)
        {
            if(dict[s[i]] == 1)
                return i;
        }
        return -1;
    }
}

//Space complexity : O(1) because English alphabet contains 26 letters.
public class Solution1 {
    public int FirstUniqChar(string s) {        
        Dictionary<char, (int, int)> dict = new();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (!dict.ContainsKey(s[i]))
            {
                dict.Add(c, (i, 1));
            }
            else
            {
                var (index, count) = dict[c];
                dict[c] = (index, count + 1);
            }
        }
        
        int result = int.MaxValue;
        foreach (var (index, count) in dict.Values)
        {
            if(count == 1 && result > index)
                result = index;
        }
        return result == int.MaxValue ? -1 : result;
    }
}