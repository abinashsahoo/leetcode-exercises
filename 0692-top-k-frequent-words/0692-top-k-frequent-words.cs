public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        return words.GroupBy(w => w).OrderByDescending(g => g.Count())
            .Select(g => new { Frequency = g.Count(), Word = g.First() })
            .OrderByDescending(i => i.Frequency).ThenBy(i => i.Word)
            .Select(i => i.Word)
            .Take(k)
            .ToList();
    }
}