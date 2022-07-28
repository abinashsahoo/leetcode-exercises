public class Solution {
    public bool IsAnagram(string s, string t) {
        var dictionary = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if (!dictionary.ContainsKey(c))
            {
                dictionary.Add(c, 1);
            }
            else
            {
                dictionary[c]++;
            }
        }
        
        foreach(var c in t)
        {
            if (!dictionary.ContainsKey(c) || dictionary[c] == 0) //<= 0 not really required because we are reducing 1 by 1
            {
                return false;
            }
            else
            {
                dictionary[c]--;
            }
        }
        
        return !dictionary.Values.Any(v => v > 0);
    }
}