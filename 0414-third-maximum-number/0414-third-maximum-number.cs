public class Solution {
    public int ThirdMax(int[] nums) {
        var orderedList = nums.Distinct().OrderByDescending(n => n);
        return orderedList.Count() < 3 ? orderedList.First() : orderedList.Skip(2).First();
    }
}

public class SecondMinSolution {
    public int SecondMin(int[] nums) {
        var comparer = Comparer<int>.Create((a, b) => b.CompareTo(a));
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(comparer);
          
        foreach (int n in nums)
        {
            if (pq.Count == 2)
            {
                if (n < pq.Peek())
                {
                    pq.Dequeue();
                    pq.Enqueue(n, n);
                }
            }
            else
            {
                pq.Enqueue(n, n);
            }
        }
     
        return pq.Peek();
    }
}