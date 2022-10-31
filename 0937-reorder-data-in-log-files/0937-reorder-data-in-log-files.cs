//QuichSort has worst time complexity of O(N^2)
//The LINQ OrderBy(...).ThenBy(...)...ThenBy(...) method chain form a single sort operation by multiple sort keys 
//(using multi key comparer).
public class Solution1 {
    public string[] ReorderLogFiles(string[] logs) {
        // if (logs == null || logs.Length == 0) 
        //     return logs;
        //n-Number of logs, M - max length of a log
        //Time: O(M.N) + O(M.NlogN) + O(M.NlogN)??
        var letterLogs = logs.Where(l => !l.Split(" ")[1].Any(c => char.IsDigit(c))) //char.IsDigit; not c.IsDigit
            .OrderBy(l => l.Substring(l.IndexOf(" ")))
            .ThenBy(l => l.Substring(0, l.IndexOf(" "))); //Substring - 1-s
        
        //Time: O(M.N)
        var digitLogs = logs.Where(l => l.Split(" ")[1].Any(char.IsDigit));
        return letterLogs.Union(digitLogs).ToArray();
    }
}
//Time: O(M.NlogN) => comparison between two keys can take up to \mathcal{O}(M)O(M) time. Does it? Tuple is a valuetype!
public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        // if (logs == null || logs.Length == 0) 
        //     return logs;
        
        var letterLogs = logs.Where(l => !l.Split(" ")[1].Any(c => char.IsDigit(c))) 
                             .Select(l => 
                                     new {                                        
                                            Id = (
                                                  l.Substring(l.IndexOf(" ")),//Content //NOTE: Can't Use named Tuple
                                                  l.Substring(0, l.IndexOf(" "))//Identifier
                                            ),
                                            Log = l
                                         })
                            .OrderBy(l => l.Id)
                            .Select(l => l.Log)
                            .ToArray();
        
        var digitLogs = logs.Where(l => l.Split(" ")[1].Any(char.IsDigit));
        return letterLogs.Union(digitLogs).ToArray();
    }
}