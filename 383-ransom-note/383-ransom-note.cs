public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        int[] map = new int[26];
        foreach (char c in magazine)
        {
            map[c - 'a']++;
        }
        
        foreach (char c in ransomNote)
        {
            map[c - 'a']--;
            if (map[c - 'a'] < 0) //NOT <= because -- is happening before
            {
                return false;
            }
        }
        return true;
    }
}