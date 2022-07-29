public class Solution {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        var result = new List<string>();
        foreach (var word in words)
        {
            if (IsMatch(word, pattern))
            {
               result.Add(word);
            }
        }
        return result;
    }
    
    private bool IsMatch(string word, string pattern)
    {
        var dict = new Dictionary<char, char>();
        
        for (int i = 0; i < pattern.Length; i++)
        {
            char p = pattern[i];
            char w = word[i];

            if(!dict.ContainsKey(p))
            {
                if(dict.ContainsValue(w)) //This is O(n) same as dict.Values.Count()
                    return false;
                dict[p] = w;
            }
            else if (dict[p] != w)
            {
                return false;
            }
        }        
        return true;
    }
}

//Test case: ["ef","fq","ao","at","lx"], pattern = "ya"
public class Solution3 {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        var result = new List<string>();
        foreach (var word in words)
        {
            if (IsMatch(word, pattern))
            {
               result.Add(word);
            }
        }
        return result;
    }
    
    private bool IsMatch(string word, string pattern)
    {
        var dict = new Dictionary<char, char>();
        
        for (int i = 0; i < pattern.Length; i++)
        {
            char p = pattern[i];
            char w = word[i];

            if(!dict.ContainsKey(p))
            {
                dict[p] = w;
            }
            else if (dict[p] != w)
            {
                return false;
            }
        }
        
        //if(dict.Values.GroupBy(v => v).Any(v => v.Count() > 1)) //If Any duplicate map?
        if(dict.Values.Distinct().Count() != pattern.Distinct().Count())
            return false;
        else
            return true;
    }
}

public class Solution2 {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        var result = new List<string>();
        foreach (var word in words)
        {   
            if (IsMatch(word, pattern))
            {
               result.Add(word);
            }
        }
        return result;
    }
    
    private bool IsMatch(string word, string pattern)
    {
        var dict1 = new Dictionary<char, char>();
        var dict2 = new Dictionary<char, char>();
        
        for (int i = 0; i < pattern.Length; i++)
        {
            char p = pattern[i];
            char w = word[i];

            if(!dict1.ContainsKey(p))
            {
                dict1[p] = w;
            }
            if(!dict2.ContainsKey(word[i]))
            {
                dict2[w] = p;
            }

            if (dict1[p] != w || dict2[w] != p)
            {
                return false;
            }
        }
        return true;
    }
}

//Won't work
//Test case: ["ef","fq","ao","at","lx"], pattern = "ya"
public class Solution1 {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        var result = new List<string>();
        foreach (var word in words)
        {
            var dict = new Dictionary<char, char>();
            bool isMatch = true;
            for (int i = 0; i < pattern.Length; i++)
            {
                var c = pattern[i];
                if(!dict.ContainsKey(c) && !dict.ContainsKey(word[i]))
                {
                    dict[c] = word[i];
                    dict[word[i]] = c;
                }
                else if(!dict.ContainsKey(c))
                {
                    if (dict.ContainsKey(word[i])) //Test Case: ["ccc"], pattern = "abb"
                    {
                        if (dict[word[i]] != c)
                        {
                            isMatch = false;
                            break;
                        }
                    }
                }
                else if (dict[c] != word[i])
                {
                    isMatch = false;
                    break;
                }
            }
            
            if (isMatch)
            {
               result.Add(word);
            }
        }
        return result;
    }
}