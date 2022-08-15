public class Solution {
    public int RomanToInt(string s) {
        var dict = new Dictionary<char, int>();
        dict.Add('I', 1);
        dict.Add('V', 5);
        dict.Add('X', 10);
        dict.Add('L', 50);
        dict.Add('C', 100);
        dict.Add('D', 500);
        dict.Add('M', 1000);
        
        int result = 0;
        int previous = 1000;//Max
        foreach (char c in s)
        {
            int current = dict[c];
            result += current;
            if (previous < current)
            {
                result -= 2 * previous; 
            }            
            previous = current;
        }
        return result;
    }
}

public class Solution1 {
    public int RomanToInt(string s) {
        var dict = new Dictionary<char, int>();
        dict.Add('I', 1);
        dict.Add('V', 5);
        dict.Add('X', 10);
        dict.Add('L', 50);
        dict.Add('C', 100);
        dict.Add('D', 500);
        dict.Add('M', 1000);
        
        int result = 0;
        char? prev = null;
        foreach (char c in s)
        {
            result += dict[c];
            if (new char[] { 'V', 'X' }.Contains(c) && prev == 'I')
            {
               result -= 2; 
            }
            else if (new char[] { 'L', 'C' }.Contains(c) && prev == 'X')
            {
               result -= 20; 
            }
            else if (new char[] { 'D', 'M' }.Contains(c) && prev == 'C')
            {
               result -= 200; 
            }
            prev = c;
        }
        return result;
    }
}