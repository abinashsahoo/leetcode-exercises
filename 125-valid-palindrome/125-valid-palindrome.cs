//Testcase: "0P"
//testCase: ".,"
public class Solution {
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
    
    private bool IsValidChar(char c) => c >= '0' && c <= '9' || c >= 'a' && c <= 'z';
}