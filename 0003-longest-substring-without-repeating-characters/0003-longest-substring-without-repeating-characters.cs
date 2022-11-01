//Testcase: "abc"
//Testcase: "dvdf"
//Testcase: "abcabcbb"
//Testcase: "pwwkew" and "pakkew"
//Testcase "ckilbkd" and "nfpdmpi" and "tmmzuxt"
public class Solution {
 
        // Sliding Window
    public int LengthOfLongestSubstring(string s) {
        
        if(string.IsNullOrEmpty(s)) return 0;
        
        Dictionary<char, int> map = new();//current char and it's index
        int left = 0, right = 0;
        int result = 0;
        while (right < s.Length)
        {
            char c = s[right];
            if (map.ContainsKey(c))
            {
                            
                left = Math.Max(map[c] + 1, left); // Because Left might be ahead already
            }
            map[c] = right;
            right++;
            result = Math.Max(result, right - left);   
        }
        
        return result;//Math.Max(result, right - left); //Imp!
    }
    
    //NOTE This is more intuitive; but can be simplified!
    // Sliding Window
//     public int LengthOfLongestSubstring(string s) {
        
//         if(string.IsNullOrEmpty(s)) return 0;
        
//         Dictionary<char, int> map = new();//current char and it's index
//         int left = 0, right = 0;
//         int result = 0;
//         while (right < s.Length)
//         {
//             char c = s[right];
//             if (!map.ContainsKey(c))
//             {
//                 map[c] = right;
//                 right++;
//             }
//             else
//             {
//                 result = Math.Max(result, right - left);               
//                 left = Math.Max(map[c] + 1, left);
//                 map[c] = right;
//                 right++;
//             }
//         }
        
//         return Math.Max(result, right - left); //Imp!
//     }
    
    public int LengthOfLongestSubstring3(string s) { 
        
        int maxLen = 0;
        Dictionary<char, int> map = new();//current index of character
    
        int left = 0, right = 0;
        while(right < s.Length) 
        {
            char c = s[right];
            if(map.ContainsKey(c))
            {
                int index = map[c];//index of existing repeating char
                //Not simply index + 1; because all <=index chars should be out of scope bull still in the dictionary
                left = Math.Max(index + 1, left); 
            }                  
                
            map[c] = right;
            right++;
            maxLen = Math.Max(maxLen, right - left);
        }

        return maxLen;
    }
        
    public int LengthOfLongestSubstring2(string s) {        
        int maxLen = 0;
        HashSet<char> window = new();
    
        int left = 0, right = 0;
        while(right < s.Length) 
        { 
            while(window.Contains(s[right]))
            {
                window.Remove(s[left]);
                left++;
            }                  
            window.Add(s[right]);
            right++;
            maxLen = Math.Max(maxLen, right - left);
        }

        return maxLen;
    }
    
    // Sliding Window
    public int LengthOfLongestSubstring1(string s) {
        
        if(string.IsNullOrEmpty(s)) return 0;
        
        var set = new HashSet<char>();
        set.Add(s[0]); //Because right starts from 1
        int left = 0;
        int right = 1;
        int result = 1;
        while (right < s.Length)
        {
            if (!set.Contains(s[right]))
            {
                set.Add(s[right]);
                right++;
            }
            else
            {
                result = Math.Max(result, right - left);
                //Console.WriteLine($"Here -> {left} - {right}");
                while (s[left] != s[right]) //until found the repeating char
                {
                    //Console.WriteLine($"{left} - {right}");
                    set.Remove(s[left]);
                    left++;
                }                
                left++;
                right++;
            }
        }
        
        return Math.Max(result, right - left); //Imp!
    }
}