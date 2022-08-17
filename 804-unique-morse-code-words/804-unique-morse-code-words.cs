public class Solution {
    public int UniqueMorseRepresentations(string[] words) 
    {
       var MORSE = new String[]
                        {".-","-...","-.-.","-..",".","..-.","--.",
                         "....","..",".---","-.-",".-..","--","-.",
                         "---",".--.","--.-",".-.","...","-","..-",
                         "...-",".--","-..-","-.--","--.."};
        HashSet<string> seen = new();
        foreach(var word in words)
        {
            StringBuilder sb = new();
            foreach (var c in word)
            {
                sb.Append(MORSE[c - 'a']);
            }
            
            seen.Add(sb.ToString());
        }
        return seen.Count;
    }
}