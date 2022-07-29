public class Solution {
    public int StrStr(string haystack, string needle) {
        if (string.IsNullOrEmpty(needle))
        {
            return 0;
        }
        
        if (needle.Length > haystack.Length)
        {
            return -1;
        }
        
        int p1 = 0;
        int p2 = 0;
        int p3 = 0;
        while (p1 < haystack.Length && p2 < haystack.Length && p3 < needle.Length)
        {
            if (needle[0] != haystack[p1])
            {                
                p1++;
                p2++;
            }
            else if (needle[p3] == haystack[p2])
            {
                p2++;
                p3++;
            }
            else
            {
                p1++;
                p2 = p1;
                p3 = 0;
            }
        }
        return p3 == needle.Length ? p1 : -1; //NOT p1 == haystack.Length; Testcase: "mississippi"; "issipi"
    }
}