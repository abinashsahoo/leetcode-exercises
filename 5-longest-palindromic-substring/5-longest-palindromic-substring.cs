public class Solution {
    public string LongestPalindrome(string s) {
        string result = string.Empty;
        for (int left = 0; left < s.Length; left++)
        {
            for (int right = left; right < s.Length; right++)//it should start at "left"
            {
                int substringLength = right - left + 1;
                if (IsPalindrome(s, left, right) && result.Length < substringLength)
                {                
                    result = s.Substring(left, substringLength);                    
                }
            }            
        }
        return result;
    }
    
    private bool IsPalindrome(string s, int substringStart, int substringEnd)
    {
        //Console.WriteLine(s.Substring(substringStart, substringEnd - substringStart + 1));
        
        int start = substringStart;
        int end = substringEnd;
        
        while (start < end)
        {
            if (s[start] != s[end])
            {
                return false;                
            }
            
            start++;
            end--;
        }
        return true;
    }
}

// Incorrect: "ba" is not palindrome, but "bab" is. So we can't slide the window. We have to test all substrings
public class Solution1 {
    public string LongestPalindrome(string s) {
        int left = 0;
        int right = 0;
        string result = string.Empty;
        while (right < s.Length)
        {
            if (IsPalindrome(s, left, right) && result.Length < right - left + 1)
            {                
                result = s.Substring(left, right - left + 1);
                right++;
            }
            else
            {
                left++;
                right++;
            }
        }
        return result;
    }
    
    private bool IsPalindrome(string s, int substringStart, int substringEnd)
    {
        Console.WriteLine(s.Substring(substringStart, substringEnd - substringStart + 1));
        
        int start = substringStart;
        int end = substringEnd;
        
        while (start < end)
        {
            if (s[start] != s[end])
            {
                return false;                
            }
            
            start++;
            end--;
        }
        return true;
    }
}