public class Solution {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        var result = new List<string>();
        int[] targetWordCount = GetCharCounts(words2);
        foreach (var word1 in words1)
        {
            int[] arr1 = GetCharCounts(word1);
            if (IsSubset(arr1, targetWordCount))
                result.Add(word1);
        }
        return result;
    }
    
    private bool IsSubset(int[] source, int[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] < target[i])
                return false;
        }
        return true;
    }
    
    private int[] GetCharCounts(string target)
    {
        int[] arr = new int[26];
        foreach (var t in target)
        {
            arr[t - 'a']++;
        }
        return arr;
    }
    
    private int[] GetCharCounts(string[] words)
    {
        int[] arr = new int[26];
        foreach (var word in words)
        {  
            int[] wordArr = GetCharCounts(word);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = wordArr[i] > arr[i] ? wordArr[i] : arr[i];
            }            
        }
        return arr;
    }
}

//TLE
public class Solution1 {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        var result = new List<string>();
        foreach (var word1 in words1)
        {
            int subsetCount = 0;
            foreach (var word2 in words2)
            {
                if (!IsSubset(word1, word2))
                    break;
                subsetCount++;
            }
            if (words2.Length == subsetCount)
                result.Add(word1);
        }
        return result;
    }
    
    private bool IsSubset(string source, string target)
    {
        if (source.Length < target.Length)
        {
            return false;
        }
        
        var dict = new Dictionary<char, int>();
        for (int i = 0; i < source.Length; i++)
        {
            char s = source[i];
            dict[s] = dict.ContainsKey(s) ? dict[s] + 1: 1;
        }
        
        for (int i = 0; i < target.Length; i++)
        {
            char t = target[i];
            if (!dict.ContainsKey(t) || dict[t] == 0)
            {
                return false;
            }
            dict[t]--;
        }
        return true;
    }
}