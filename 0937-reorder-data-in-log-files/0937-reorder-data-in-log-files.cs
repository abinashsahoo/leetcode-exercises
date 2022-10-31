public class Solution {
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