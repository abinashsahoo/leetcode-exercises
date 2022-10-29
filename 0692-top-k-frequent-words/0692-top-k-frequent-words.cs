//What's the value of k? What's the Max length of words? What's the size of the array?
// no new unique words will be added later?
//uppercase or lowercase?

//MinHeap
// O (NlogK)= k ≤ N; O(N)+O(Nlogk)+O(klogk) = O(Nlogk)
//O(N)
public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        var wordFrequency = words.GroupBy(w => w)
                            .Select(g => new { Word = g.Key, Priority = (g.Count(), g.Key) });
        //var pq = new PriorityQueue<string,(int, string)>(new FrequencyComparer());
        var pq = new PriorityQueue<string,(int, string)>
            (
                Comparer<(int, string)>.Create((a, b) =>
                      a.Item1 == b.Item1 ? b.Item2.CompareTo(a.Item2) : a.Item1.CompareTo(b.Item1))
            );
        foreach (var wf in wordFrequency)
        {
            pq.Enqueue(wf.Word, wf.Priority);
            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }        
        
        var result = new List<string>();
        while (pq.Count > 0)
        {
            result.Add(pq.Dequeue());
        }
        result.Reverse();
        return result;
    }
    
    // class FrequencyComparer : IComparer<(int, string)>
    // {
    //     public int Compare((int, string) x, (int,string) y)
    //     {
    //         if (x.Item1 == y.Item1)
    //         {
    //             return y.Item2.CompareTo(x.Item2);//NOTE: this is reversed
    //         }
    //         return x.Item1.CompareTo(y.Item1);
    //     }
    // }
}

//MaxHeap
//when the given input is off-line, i.e., no new unique words will be added later
//Time: O(N + klogN)
//Space: O(N)
public class SolutionMaxHeap {
    public IList<string> TopKFrequent(string[] words, int k) {
        var wordFrequency = words.GroupBy(w => w)
                            .Select(g => (g.Key, (g.Count(), g.Key)));//ValueTuple of (Element, Priority)
        
        //Constructs the heap using a heapify operation, which is generally faster than 
        //enqueuing individual elements sequentially. O(N)
        var pq = new PriorityQueue<string,(int, string)>(wordFrequency, new FrequencyComparer());
        var result = new List<string>();
        for (int i = 0; i < k; i++)
        {
            result.Add(pq.Dequeue());
        }
        return result;
    }
    
    class FrequencyComparer : IComparer<(int, string)>
    {
        public int Compare((int, string) x, (int,string) y)
        {
            if (x.Item1 == y.Item1)
            {
                return x.Item2.CompareTo(y.Item2);
            }
            //return y.CompareTo(x);
            //OR
            return y.Item1.CompareTo(x.Item1);
        }
    }
}

//Time: O(NlogN)
//Space: O(N)
public class SolutionLinq {
    public IList<string> TopKFrequent(string[] words, int k) {
        return words.GroupBy(w => w)
            .OrderByDescending(g => g.Count()).ThenBy(i => i.Key)
            .Select(g => g.Key)
            .Take(k)
            .ToList();
    }
}

public class Solution1 {
    public IList<string> TopKFrequent(string[] words, int k) {
        return words.GroupBy(w => w)
            .Select(g => new { Frequency = g.Count(), Word = g.Key })//g.Key , it's better that g.First()
            .OrderByDescending(i => i.Frequency).ThenBy(i => i.Word)
            .Select(i => i.Word)
            .Take(k)
            .ToList();
    }
}

public class Solution0 {
    public IList<string> TopKFrequent(string[] words, int k) {
        return words.GroupBy(w => w).OrderByDescending(g => g.Count())
            .Select(g => new { Frequency = g.Count(), Word = g.First() })
            .OrderByDescending(i => i.Frequency).ThenBy(i => i.Word)
            .Select(i => i.Word)
            .Take(k)
            .ToList();
    }
}