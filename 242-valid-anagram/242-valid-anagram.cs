public class Solution2 {
    public bool IsAnagram(string s, string t) {
        return s.OrderBy(c => c).SequenceEqual(t.OrderBy(c => c));
    }
}

public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length)
        {
            return false;
        }
        
        var dictionary = new Dictionary<char, int>();
        foreach(var i in s)
        {
            dictionary[i] = dictionary.ContainsKey(i) ? (dictionary[i] + 1) : 1;
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

public class Solution1 {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length)
        {
            return false;
        }
        
        var sArray = s.ToCharArray();
        var tArray = t.ToCharArray();
        
        Array.Sort(sArray);
        Array.Sort(tArray);
        
        //return Enumerable.SequenceEqual(sArray, tArray); //NOTE
        return sArray.SequenceEqual(tArray);
    }
}