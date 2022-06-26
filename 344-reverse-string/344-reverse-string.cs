public class Solution {
    
    //Two Pointers - O(N) Time; O(1) Space
    public void ReverseString(char[] s) {
        
        int start = 0;
        int end = s.Length - 1;        
        while(start < end)
        {
            var temp = s[start];
            s[start] = s[end];
            s[end] = temp;            
            start++;
            end--;
        }
    }
    
    //Recursion - O(N) Time; O(N) Space
    public void ReverseString1(char[] s) {        
        ReverseString(s, 0, s.Length - 1);
    }
    
    private void ReverseString(char[] s, int start, int end) {
        if(start >= end) return;        
        var temp = s[start];
        s[start] = s[end];
        s[end] = temp;
        ReverseString(s, ++start, --end); //NOTE: Not ReverseString(s, start++, end--);
    
        // var temp = s[start];
        // s[start++] = s[end];
        // s[end--] = temp;
        // ReverseString(s, start, end);
    }

    //Not in-place
    public void ReverseString2(char[] s) {        
        string reverseString = string.Empty;
        for (int i = 1; i <= s.Length; i++)
        {
            reverseString += s[^i];
        }
        Console.WriteLine(reverseString);
    }
  
    //Not in-place
    public void ReverseString3(char[] s) {        
        string reverseString = string.Empty;
        foreach (char c in s)
        {
            reverseString = c + reverseString;
        }
        Console.WriteLine(reverseString);
    }
      
    public void ReverseString4(char[] s) {        
        Array.Reverse(s); //NOTE: s.Reverse() generates a new array
    }

}