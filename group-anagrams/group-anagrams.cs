public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        if (strs == null || strs.Length == 0)
        {
            return new List<IList<string>>();            
        }
        
        List<IList<string>> res = new List<IList<string>>();
        var dict = new Dictionary<string, List<string>>();
        
        foreach (var str in strs)
        {
            string cur = new string(str.OrderBy(x => x).ToArray());
            
            if (!dict.ContainsKey(cur))
                dict.Add(cur, new List<string>());
            
            dict[cur].Add(str);
        }
        
        foreach (var item in dict.Values)
        {
            res.Add(item);            
        }
        
        return res;
    }
}

//Question: Does it contain only lower case?
//TLE
public class Solution1 {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var result = new List<IList<string>>();
        //var seen = new HashSet<string>();//String set won't work if we have duplicates: ["aaa","aaa"]; save index instead
        var seen = new HashSet<int>();
        for (int i = 0; i < strs.Length; i++)
        {
            if (!seen.Contains(i))
            {
                var list = new List<string>();
                for (int j = i; j < strs.Length; j++)
                {
                    if(!seen.Contains(j) && IsAnagram(strs[i], strs[j]))
                    {
                        seen.Add(j);
                        list.Add(strs[j]);
                    }                    
                }
                result.Add(list);                
            }
        }
        return result;
    }
    
    private bool IsAnagram(string source, string target)
    {
        //Console.WriteLine($"{source}-{target}");
        
        if (source.Length != target.Length) 
        {
            return false;
        }
        
        var dict = new Dictionary<char, int>();        
        for (int i = 0; i < source.Length; i++)
        {
            char s = source[i];
            char t = target[i];
            
            dict[s] = dict.ContainsKey(s) ? dict[s] + 1 : 1;
            dict[t] = dict.ContainsKey(t) ? dict[t] - 1 : -1;
        }
        
        return dict.Values.Count(v => v != 0) == 0;
    }
}