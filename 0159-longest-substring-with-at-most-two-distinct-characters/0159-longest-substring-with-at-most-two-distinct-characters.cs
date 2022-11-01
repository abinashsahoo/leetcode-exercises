public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        var dict = new Dictionary<char, int>();
        int l = 0, r = 0, max = 0;
        while(r < s.Length)
        {
            var c = s[r];
            dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
            
            if(dict.Count > 2)//dict.Keys.Count
            {
                //delete the leftmost character, reduce count
                dict[s[l]]--;
                if (dict[s[l]] == 0)
                    dict.Remove(s[l]);
                l++;
            }
            
			r++;
            max = Math.Max(max, r-l);
        }
        return max;
    }
}

//TC: "ccaabbb"
public class Solution2 {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        int left = 0;
        int right = 0;
        int max = 0;
        int count = 0;
        var set = new HashSet<char>();
        while (left <= right && right < s.Length)
        {
            var c = s[right];
            if (set.Count < 2 || set.Count == 2 && set.Contains(c))
            {
                count++;
                right++;
                if (!set.Contains(c))
                    set.Add(c);
            }
            else
            {
                max = Math.Max(max, count);
                count = 0;
                var leftChar = s[left];
                while(leftChar == s[left]) // Remove 1 char
                {
                    set.Remove(leftChar);
                    left++;
                }                    
                right = left;
            }                
        }
        return Math.Max(max, count); // Important
    }
}

//TC: "ccaabbb"
public class Solution1 {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        int left = 0;
        int right = 0;
        int max = 0;
        int count = 0;
        var set = new HashSet<char>();
        while (left <= right && right < s.Length)
        {
            var c = s[right];
            if (set.Count < 2 || set.Count == 2 && set.Contains(c))
            {
                count++;
                right++;
                if (!set.Contains(c))
                    set.Add(c);
            }
            else
            {
                max = Math.Max(max, count);
                count = 0;
                set = new HashSet<char>();
                left++;
                right = left;
            }                
        }
        return Math.Max(max, count); // Important
    }
}