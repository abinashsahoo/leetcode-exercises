public class WordDictionary {
    private Dictionary<char, WordDictionary> children;
    bool isEndOfWord;
    
    public WordDictionary() {
        children = new();
    }
    
    public void AddWord(string word) {
        WordDictionary curr = this;
        foreach(char c in word)
        {
            if (!curr.children.ContainsKey(c))
            {
                curr.children[c] = new WordDictionary();
            }
            curr = curr.children[c];
        }
        curr.isEndOfWord = true;
    }
    
    public bool Search(string word) {        
        WordDictionary curr = this;
        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            if (!curr.children.ContainsKey(c))
            {
                if(c == '.')
                {
                    foreach (var ch in curr.children.Values)
                    {
                        if (ch.Search(word.Substring(i + 1)))
                            return true;
                    }
                }
                return false;
            }
            else
            {
                curr = curr.children[c];
            }            
        }
        return curr.isEndOfWord;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */