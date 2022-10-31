//QuichSort has worst time complexity of O(N^2)


//The LINQ OrderBy(...).ThenBy(...)...ThenBy(...) method chain form a single sort operation by multiple sort keys 
//(using multi key comparer).
public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        // if (logs == null || logs.Length == 0) 
        //     return logs;
        //n-Number of logs, M - max length of a log
        //Time: O(M.N) + O(M.NlogN) + O(M.NlogN)??
        var letterLogs = logs.Where(l => !l.Split(" ")[1].Any(c => char.IsDigit(c))) //char.IsDigit; not c.IsDigit
            .OrderBy(l => l.Substring(l.IndexOf(" ") + 1))
            .ThenBy(l => l.Substring(0, l.IndexOf(" "))); //Substring - 1-s
        
        //Time: O(M.N)
        var digitLogs = logs.Where(l => l.Split(" ")[1].Any(char.IsDigit));
        return letterLogs.Union(digitLogs).ToArray();
    }
}
//Time: O(M.NlogN) => comparison between two keys can take up to \mathcal{O}(M)O(M) time. Does it? Tuple is a valuetype!
public class Solution0 {
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

public class SolutionDoesnotWorkWithDupKey {
    public string[] ReorderLogFiles(string[] logs) {
           //SortedList - Add: This method is an O(n) operation for unsorted data, where n is Count. It is an O(log n) operation if //the new element is added at the end of the list. If insertion causes a resize, the operation is O(n).
            SortedList<string, string> letterLog = new SortedList<string, string>();
            List<string> digitLogs = new List<string>(),
                         result = new List<string>();

            foreach (var item in logs)
                if (item[item.IndexOf(' ') + 1] >= 'a' && item[item.IndexOf(' ') + 1] <= 'z')
                    letterLog.Add(item.Substring(item.IndexOf(' ') + 1), item);
                else
                    digitLogs.Add(item);

            foreach (var item in letterLog)
                result.Add(item.Value);

            foreach (var item in digitLogs)
                result.Add(item);

            return result.ToArray();
    }
}

public class SolutionDoesnotWorkWithDup {
    public string[] ReorderLogFiles(string[] logs) {
        //SortedList - Add: This method is an O(n) operation for unsorted data, where n is Count. It is an O(log n) operation if //the new element is added at the end of the list. If insertion causes a resize, the operation is O(n).
        
            var letterLogs = new SortedDictionary<string, HashSet<string>>();
            var digitLogs = new List<string>();
            bool IsDigitLog(string s) => char.IsDigit(s[s.IndexOf(" ") + 1]);
            foreach (var log in logs)
                if(!IsDigitLog(log))
                {
                    var key = log.Substring(log.IndexOf(' ') + 1);
                    if(!letterLogs.ContainsKey(key))//ContainsKey is O(log(n))
                        letterLogs[key] = new HashSet<string>() { log };
                    else
                    {                        
                        //This method is an O(log n) operation, where n is Count.
                        letterLogs[key].Add(log);                        
                    }
                }                    
                else
                    digitLogs.Add(log);
        
            var result = new List<string>();
            foreach (var dv in letterLogs)
                result.AddRange(dv.Value);
            
        return result.Union(digitLogs).ToArray();
            //Won't work for SortedSet
            //return letterLog.Values.Union(digitLogs).ToArray();
    }
}

//NOTE: Array.Sort in c# is not a stable sort!
public class SolutionNotStableDoesNOTWORK {
    public string[] ReorderLogFiles(string[] logs) {
        var comparer = Comparer<string>
            .Create((s1, s2) =>
           {
               var split1 = s1.Split(" ", 2);//2 is important, because 2nd part is the content
               var split2 = s2.Split(" ", 2);
               bool IsDigitLog(string[] s) => s[1].Any(char.IsDigit);
               if (!IsDigitLog(split1) && !IsDigitLog(split2))
               {
                   int comp = split1[1].CompareTo(split2[1]);
                   if (comp != 0)//Not equals content
                   {
                       return comp;
                   }
                   return split1[0].CompareTo(split2[0]);
               }
               
               if (!IsDigitLog(split1) && IsDigitLog(split2))
                   return -1;
               else if (IsDigitLog(split1) && !IsDigitLog(split2))
                   return 1;  
               else
                    return 0;//both are digit logs
             });
        Array.Sort(logs, comparer);
        return logs;
    }
}
