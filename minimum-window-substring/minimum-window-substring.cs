//Time: O(N)
//Space: Should be constant space if (distinct types of char)
//Time: O(N)
//Space: Should be constant space if (distinct types of char)
public class Solution {
    public string MinWindow(string s, string t) {
        int[] map = CreateCharacterMap(t);       
        int counter = t.Length;//All chars
        int left = 0, right = 0, minLength = int.MaxValue, minStart = 0;
        while (right < s.Length)
        {
            char rightChar = s[right];
            if (map[rightChar] > 0) 
                counter--;
            map[rightChar]--; //Let it go negative
            right++;
            while (counter == 0)
            {
                if (right - left < minLength)
                {
                    minLength = right - left;
                    minStart = left;
                }
                char leftChar = s[left];
                map[leftChar]++;
                if (map[leftChar] > 0) 
                    counter++;
                left++;
            }
        }
        return minLength == int.MaxValue ? "" : s.Substring(minStart, minLength);
    }
    
    private int[] CreateCharacterMap(string t)
    {
        int [] map = new int[128];
        foreach (var c in t)
        {
            map[c]++;
        }
        return map;
    }
}

public class Solution1 {
    public string MinWindow(string s, string t) {
        Dictionary<char, int> dict = CreateCharacterMap(t);
        string result = "";
        // Number of unique characters in t, which need to be present in the desired window.
        int counter = dict.Count;//Might contain dups char
        int left = 0, right = 0, minLength = s.Length + 1;//minStart = 0
        while (right < s.Length)
        {
            char rightChar = s[right];
            if (dict.ContainsKey(rightChar))// && dict[rightChar] > 0) //Let it go negative?
            {
                dict[rightChar]--;
                if(dict[rightChar] == 0)
                    counter--;
            }
            right++;
            while (counter == 0)
            {
                if (right - left < minLength)
                {
                    minLength = right - left;
                    //minStart = left;
                    result = s.Substring(left, minLength);
                }
                char leftChar = s[left];
                if (dict.ContainsKey(leftChar))// && dict[s[left]] == 0)
                {
                    dict[leftChar]++;
                    if (dict[leftChar] > 0)
                        counter++;
                }
                left++;
            }
        }
        //return d == int.MaxValue ? "" : s.Substring(minStart, minLength);
        return result;
    }
    
    private Dictionary<char, int> CreateCharacterMap(string t)
    {
        Dictionary<char, int> dict = new();
        foreach (var c in t)
        {
            dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
        }
        return dict;
    }
}