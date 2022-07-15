public class Solution {
    HashSet<(int, int)> visited = new();    
    public int MaxAreaOfIsland(int[][] grid) {
        int maxArea = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1 && !visited.Contains((i, j)))
                {
                    int area = CalculateArea(grid, i, j);
                    maxArea = Math.Max(area, maxArea);
                }
            }
        }
        return maxArea;
    }

    private int CalculateArea(int[][] grid, int i, int j)
    {        
        Queue<(int, int)> queue = new();
        Enqueue(queue, i, j, grid);
        
        int area = 0;
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            area++; 
            
            Enqueue(queue, x - 1, y, grid);
            Enqueue(queue, x, y + 1, grid);
            Enqueue(queue, x + 1, y, grid);
            Enqueue(queue, x, y - 1, grid);            
        }
        
        return area;
    }
    
    private void Enqueue(Queue<(int, int)> queue, int i, int j, int[][] grid)
    {
        if (i < 0 || j < 0) return;
        if(i >= grid.Length || j >= grid[0].Length) return;
        if(visited.Contains((i, j))) return;

        if(grid[i][j] == 1)
        {
            queue.Enqueue((i, j));
            visited.Add((i, j));
        }
    }
}