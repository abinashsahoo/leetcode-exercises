
//PriorityQueue - Simplified
//Time: O(NLogK)
//Space: O(K)
public class Solution {
        public int[][] KClosest(int[][] points, int k)
        {
            int GetDistance(int x, int y) => x * x + y * y;

            var pq = new PriorityQueue<int[], int>(new DistanceComparer());
            foreach (var p in points)
            {
                int distance = GetDistance(p[0], p[1]);
                pq.Enqueue(p, distance);
                
                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }
            //(Element, Priority) -> Tuple
            //return pq.UnorderedItems.Select(i => i.Element).ToArray();
            
            int[][] res = new int[k][];
            while (k > 0) {
                res[--k] = pq.Dequeue();
            }
            return res;
        }
    
        private class DistanceComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
}
//Time: O(NLogK)
//Space: O(K)
public class SolutionPQ {
        public int[][] KClosest(int[][] points, int k)
        {
            int GetDistance(int x, int y) => x * x + y * y;
            //var pq = new PriorityQueue<int[], int>(k, new DistanceComparer());
    //Or
            var pq = new PriorityQueue<int[], int>(new DistanceComparer());
            pq.EnsureCapacity(k);

            foreach (var p in points)
            {
                int distance = GetDistance(p[0], p[1]);
                if (pq.Count < k)
                {
                    pq.Enqueue(p, distance);
                }
                else
                {
                    var topP = pq.Peek();
                    int topPDistance = GetDistance(topP[0], topP[1]);
                    if (topPDistance > distance)
                    {
                        pq.Dequeue();
                        pq.Enqueue(p, distance);
                    }
                }
            }
            //(Element, Priority) -> Tuple
            return pq.UnorderedItems.Select(i => i.Element).ToArray();
        }
    
        private class DistanceComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
}
//Time: O(NLogN)
//Space: O(N)
public class Solution2 {
    public int[][] KClosest(int[][] points, int k) {
        return points.Select(p => new { Point = p, Distance = p[0]*p[0] + p[1]*p[1] }) //Not need to perform Sqrt 
            .OrderBy(d => d.Distance)
            .Select(d => d.Point)
            .Take(k).ToArray();
    }
}

public class Solution1 {
    public int[][] KClosest(int[][] points, int k) {
        return points.Select(p => new { Point = p, Distance = Math.Sqrt(p[0]*p[0] + p[1]*p[1]) })
            .OrderBy(d => d.Distance)
            .Select(d => d.Point)
            .Take(k).ToArray();
    }
}