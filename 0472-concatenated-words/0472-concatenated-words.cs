public class Solution1 {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {        
        var res = new List<string>();
        if(words == null || words.Length == 0)
            return res;
      
        var wordSet = new HashSet<string>();
        Array.Sort(words, (a,b) => a.Length - b.Length);//Length wise sorted
        foreach(var word in words)
        {
            if(IsConcatenated(word, wordSet))
                res.Add(word);
            
            wordSet.Add(word);
        }
        
        return res;
    } 
    
    public bool IsConcatenated(string word, HashSet<string> wordSet)
    {
        if(wordSet.Count == 0)
            return false;
        
        bool[] dp = new bool[word.Length + 1];
        dp[0] = true;
        
        // check substrings starting with length 1 for current word
        for(int i = 1; i <= word.Length; i++)//Max Length loop!!
        {
            // check if the substring is concatenated
            // divide the substring into 2 parts, the 1st part has length j
            //for(int j = 0; j < i; j++)//start index loop
            for (int j = i; j >= 0; j--)
            {                
                if(dp[j] && wordSet.Contains(word.Substring(j, i - j))) //String Length = i - j
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        
        return dp[word.Length];
    }
}

public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        var set = new HashSet<String>(words);
        var result = new List<string>();
        foreach(var word in words){
            var memo = new bool?[word.Length];
            set.Remove(word);
            if(helper(word, set, 0, memo))
            {
                result.Add(word);
            }
            set.Add(word);
        }
        return result;
    }
    
    private bool helper(String word, HashSet<String> set, int startIndex, bool?[] memo)
    {
        if(startIndex == word.Length)
        {
            return true;
        }
        
        if(memo[startIndex] != null)
        {
            return memo[startIndex].Value;
        }
        
        for (int end = startIndex + 1; end <= word.Length; end++)
        {
            int len = end - startIndex;
            if(set.Contains(word.Substring(startIndex, len)) && helper(word, set, end, memo))
            {
                memo[startIndex] = true;
                return true;
            }
        }
        memo[startIndex] = false;
        return false;
    }
}