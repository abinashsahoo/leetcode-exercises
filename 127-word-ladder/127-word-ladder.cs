// Question: All lowercase?
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var wordSet = new HashSet<string>(wordList);
        if(!wordSet.Contains(endWord)) return 0;
        
        var queue = new Queue<string>();
        queue.Enqueue(beginWord);  
        var visited = new HashSet<string>();
        //visited.Add(beginWord);   
        
        int level = 0;
        while (queue.Count > 0)
        {            
            level++;
            int size = queue.Count; // Important, because queue size would change
            for (int i = 0; i < size; i++)
            {                
                var word = queue.Dequeue();                
                if (word == endWord)
                {
                    return level;
                }
                  
                foreach (var neighbor in GetNeighbors(word, wordSet))
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }                  
                }
            }         
        }
        
        return 0;
    }
    
    private IEnumerable<string> GetNeighbors(string word, HashSet<string> wordSet)
    {
        return GetAllNeighbors(word).Where(w => wordSet.Contains(w));
    }
    
    private IEnumerable<string> GetAllNeighbors(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            var arr = word.ToCharArray();
            for (char c = 'a'; c <= 'z'; c++)
            {
                //if(c != arr[i])//Won't word, because arr[i] is already modified
                //if(c != word[i])
                //{
                    arr[i] = c;
                    yield return new string(arr);
               // }
            }
        }
    }
}