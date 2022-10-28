public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        return points.Select(p => new { Point = p, Distance = Math.Sqrt(p[0]*p[0] + p[1]*p[1]) })
            .OrderBy(d => d.Distance)
            .Select(d => d.Point)
            .Take(k).ToArray();
    }
}