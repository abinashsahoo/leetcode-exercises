public class WordDictionary {
    private readonly WordNode root = new WordNode();

    public void AddWord(string word) {
        var node = root;
        foreach (var c in word)
        {
            node = node.Nodes[c - 'a'] ??= new WordNode();
        }
        node.IsWord = true;
    }

    public bool Search(string word) => Search(word, 0, root);

    private bool Search(string word, int index, WordNode node) 
    {
        if (word.Length == index)
            return node.IsWord;

        return word[index] == '.'
            ? node.Nodes.Where(n => n != null).Any(n => Search(word, index + 1, n))
            : node.Nodes[word[index] - 'a'] != null
                && Search(word, index + 1, node.Nodes[word[index] - 'a']);
    }

    private class WordNode {
        public WordNode[] Nodes { get; } //NOTE: I can still do: node.Nodes[c - 'a'] ??= new WordNode();
        public bool IsWord { get; set; }

        public WordNode() {
            Nodes = new WordNode[26];
            IsWord = false;
        }
    }
}

public class WordDictionary1 {
    private Dictionary<char, WordDictionary1> children;
    bool isEndOfWord;
    
    public WordDictionary1() {
        children = new();
    }
    
    public void AddWord(string word) {
        var curr = this;
        foreach(char c in word)
        {
            if (!curr.children.ContainsKey(c))
            {
                curr.children[c] = new WordDictionary1();
            }
            curr = curr.children[c];
        }
        curr.isEndOfWord = true;
    }
    
    public bool Search(string word) {        
        var curr = this;
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