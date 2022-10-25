public class Solution {
    public string MinWindow(string s, string t) {
        Dictionary<char, int> dict = CreateCharacterMap(t);
        string result = "";
        int counter = dict.Count;//Might contain dups char
        int left = 0, right = 0, minLength = s.Length + 1;
        while (right < s.Length)
        {
            char rightChar = s[right];
            if (dict.ContainsKey(rightChar))// && dict[c] > 0) //Let it go negative
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
                    //head = left;
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
        //return d == int.MaxValue ? "" : s.Substring(head, d);
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