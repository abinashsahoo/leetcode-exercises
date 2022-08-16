public class Solution {
    public char RepeatedCharacter(string s) {
        HashSet<char> seen = new();
        foreach (char c in s)
        {
            if(seen.Contains(c))
                return c;
            else
                seen.Add(c);
        }
        return ' ';//s[0];//'\0'
    }
}

public class Solution1 {
    public char RepeatedCharacter(string s) {
        int resultIndex = int.MaxValue;
        Dictionary<char, (int, int)> set = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (!set.ContainsKey(s[i]))
            {
                set.Add(s[i], (i, 1));
            }
            else
            {
                var (index, count) = set[s[i]];
                set[s[i]] = (index, count + 1);
            }
            
            var (index1, count1) = set[s[i]]; //NOTE: Could not use (index, count) variable names here!!
            if(count1 == 2 && resultIndex > index1)
                return s[index1];
        }
        return s[0];
    }
}