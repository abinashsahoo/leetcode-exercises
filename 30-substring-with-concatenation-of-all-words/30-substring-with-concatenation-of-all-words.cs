
// NOTE: Words might have common characters
// "wordgoodgoodgoodbestword", words = ["word","good","best","word"]; "word" is 2 times

public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        int wordLength = words.First().Length;
        var substringSize = wordLength * words.Length;        
        var wordCount = new Dictionary<string, int>();
        
        foreach (var word in words)
        {
            wordCount[word] = wordCount.ContainsKey(word) ? wordCount[word] + 1 : 1;
        }
        
        //Console.WriteLine(string.Join("-", wordCount.Keys));
       // Console.WriteLine(string.Join("-", wordCount.Values));
        
        var result = new List<int>();
        for (int i = 0; i < wordLength; i++) 
        {
            SlidingWindow(i);
        }
        return result;
        
        void SlidingWindow(int left)
        {
            var wordsFound = new Dictionary<string, int>();
            int wordsUsed = 0;
            bool excessWord = false;
            
            // Iterate word_length at a time, and at each iteration we focus on one word
            for (int right = left; right <= s.Length - wordLength; right += wordLength) 
            {
                var sub = s.Substring(right, wordLength);
                if (!wordCount.ContainsKey(sub)) 
                {
                    // Mismatched word - reset the window
                    wordsFound.Clear();
                    wordsUsed = 0;
                    excessWord = false;
                    left = right + wordLength;
                } 
                else 
                {
                    // If we reached max window size or have an excess word
                    while (right - left == substringSize || excessWord) 
                    {
                        var leftmostWord = s.Substring(left, wordLength);
                        left += wordLength;
                        wordsFound[leftmostWord] = wordsFound[leftmostWord] - 1;

                        if (wordsFound[leftmostWord] >= wordCount[leftmostWord]) 
                        {
                            // This word was an excess word
                            excessWord = false;
                        } 
                        else 
                        {
                            // Otherwise we actually needed it
                            wordsUsed--;
                        }
                    }

                    // Keep track of how many times this word occurs in the window
                    wordsFound[sub] = wordsFound.ContainsKey(sub) ? wordsFound[sub] + 1 : 1;
                    if (wordsFound[sub] <= wordCount[sub]) 
                    {
                        wordsUsed++;
                    } 
                    else 
                    {
                        // Found too many instances already
                        excessWord = true;
                    }

                    if (wordsUsed == words.Length && !excessWord) 
                    {
                        // Found a valid substring
                        result.Add(left);
                    }
                }
            }
        }        
    }
}

//TLE
public class Solution1 {
    public IList<int> FindSubstring(string s, string[] words) {
        var result = new List<int>();
        int wordLength = words.First().Length;
        string[] matchingWords = words;
        int left = 0;
        int window = 0;
        int fullWindow = 0;
        //var keepMatchedWords = new HashSet<string>();
        var keepMatchedWords = new HashSet<int>();
        while (left + fullWindow < s.Length && window < wordLength)
        {
            char c = s[left + fullWindow];
            //Console.Write(c);
            // matchingWords = words.Where(w => !keepMatchedWords.Contains(w)).ToArray();//Rest of the words
            matchingWords = GetMatchingWords(matchingWords, window, c).ToArray();
           //Console.WriteLine("Here -> " + string.Join("-", matchingWords));
           //Console.WriteLine("Here -> " + string.Join("-", keepMatchedWords));
            
            if (matchingWords.Length > 0)
            {
                if (window == wordLength - 1)
                {
                    //Console.WriteLine("Here");
                    //Found 1 word match
                    //keepMatchedWords.Add(matchingWords[0]);                    
                    //matchingWords = words.Where(w => !keepMatchedWords.Contains(w)).ToArray();//Rest of the words
                    
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!keepMatchedWords.Contains(i) && matchingWords[0] == words[i])
                        {
                            keepMatchedWords.Add(i);
                            break;
                        }
                    }
                    matchingWords = words.Where((w, i) => !keepMatchedWords.Contains(i)).ToArray();//Rest of the words

                    if (matchingWords.Length == 0)//Found all words
                    {
                        result.Add(left);
                        window = 0;
                        fullWindow = 0;
                        left++;
                        keepMatchedWords.Clear();//
                        matchingWords = words;//
                    }
                    else
                    {
                        fullWindow++;
                        window = 0;                        
                    }
                }
                else
                {
                    fullWindow++;
                    window++;                        
                }
            }
            else
            {
                fullWindow = 0;
                window = 0;
                left++;
                keepMatchedWords.Clear();//
                matchingWords = words;//
            }
        }
        return result;
    }
    
    private IEnumerable<string> GetMatchingWords(string[] words, int index, char c)
    {
       // Console.WriteLine(string.Join("-", words));
        foreach (var word in words)
        {
            if (word[index] == c)
                yield return word;
        }
    }
}