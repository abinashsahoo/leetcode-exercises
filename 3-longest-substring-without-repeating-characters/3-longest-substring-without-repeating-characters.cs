//Testcase: "abc"
//Testcase: "dvdf"
//Testcase: "abcabcbb"
//Testcase: "pwwkew" and "pakkew"
//Testcase "ckilbkd" and "nfpdmpi" and "tmmzuxt"
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(string.IsNullOrEmpty(s)) return 0;
        var set = new HashSet<char>();
        set.Add(s[0]);
        int i = 0;
        int j = 1;
        int answer = 1;
        while (j < s.Length)
        {
            if (!set.Contains(s[j]))
            {
                set.Add(s[j++]);
            }
            else
            {
                answer = Math.Max(answer, j - i);
                //set.Remove(s[j]);
                //set.Add(s[j]);
                while (s[i] != s[j])
                {
                    set.Remove(s[i]);
                    i++;   
                }
                
                i++;
                j++;
                
               // Console.WriteLine($"i ={i}, j = {j}");
            }
        }
        
        return Math.Max(answer, j - i);
    }
}