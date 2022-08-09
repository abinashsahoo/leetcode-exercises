public class Solution {
    public bool IsPalindrome(string s) {
        string newStr = new string(s.ToLower().Where(c => char.IsLetterOrDigit(c)).ToArray());
        for (int i = 0; i < newStr.Length/2; i++)
        {
            if (newStr[i] != newStr[^(i+1)])//c#8
                return false;
        }
        return true;
    }
}

//Testcase: "0P"
//testCase: ".,"
public class Solution1 {
    public bool IsPalindrome(string s) {
        var lowerStr = s.ToLower();
        int left = 0;
        int right = lowerStr.Length - 1;
        while (left < right)
        {
            while (left < lowerStr.Length && !IsValidChar(lowerStr[left])) // Not If, use while
                left++;
            while (right > -1 && !IsValidChar(lowerStr[right])) // Not If, use while
                right--;
             
            if(left < right)
            {
                if(lowerStr[left++] != lowerStr[right--])
                    return false;                
            }
            
            //left++;
            //right--;
        }
        return true;
    }
    
    //Could not include  c >= 'A' && c <= 'Z' as well, because z == Z (case insensitive equality)
    private bool IsValidChar(char c) => c >= '0' && c <= '9' || c >= 'a' && c <= 'z';
}