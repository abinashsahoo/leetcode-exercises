public class Solution {
    public int NumMatchingSubseq(string s, string[] words) {
        int answer = 0;
        var dic = new Dictionary<char, List<(string, int)>>();
        foreach (var word in words)
        {
            AddItem(dic, word, 0);
        }
        
        foreach (var c in s)
        {
            if(!dic.ContainsKey(c)) continue;
            
            var oldList = dic[c];
            dic[c] = new List<(string, int)>();
            
            foreach (var (word, i) in oldList)
            {
                int index = i + 1;
                if(word.Length == index)
                {
                    answer++;
                }
                else
                {
                    AddItem(dic, word, index);
                }
            }
        }
        return answer;
    }
    
    private void AddItem(Dictionary<char, List<(string, int)>> dic, string word, int index)
    {
        if(dic.ContainsKey(word[index]))
        {
            dic[word[index]].Add((word, index));
        }
        else
        {
            dic.Add(word[index], new List<(string, int)>{ (word, index) });
        }
    }
}

//TLE
public class Solution2 {
    public int NumMatchingSubseq(string s, string[] words) {
        int answer = 0;
        foreach (var word in words)
        {
            if(IsSubsequence(s, word))
            {
                answer++;
            }
        }
        return answer;
    }
    
    private bool IsSubsequence(string s, string word) {
        int i = 0;
        foreach (var schar in s)
        {
            if(i == word.Length) break;
            if(schar == word[i]) i++;
        }
        return i == word.Length;
    }
}

public class Solution1 {
    public int NumMatchingSubseq(string s, string[] words) {
        int answer = 0;
        foreach (var word in words)
        {
            if(IsSubstring(s, word))
            {
                answer++;
            }
        }
        return answer;
    }
    
    private bool IsSubstring(string s, string word) {
        int i = 0;
        int j = 0;
        bool result = false;
        while (i < s.Length)
        {
            if(s[i] == word[j])
            {
                i++;
                j++;
                result = true;
            }
            else
            {
                if(j == 0)
                    i++;
                else
                {                   
                    j = 0; 
                }
                result = false;
            }
        }
        return result;
    }
    
    private bool IsSubstring1(string s, string word) {
        int i = 0;
        int j = 0;
        bool result = false;
        while (i < s.Length && j < word.Length)
        {
            if(s[i] == word[j])
            {
                i++;
                j++;
                result = true;
            }
            else
            {
                if(j == 0)
                    i++;
                else
                {                   
                    j = 0; 
                }
                result = false;
            }
        }
        return result;
    }
}