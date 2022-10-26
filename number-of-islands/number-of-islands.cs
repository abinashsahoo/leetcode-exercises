//Time: O(MxN)
//Space: O(MxN)//in case that the grid map is filled with lands where DFS goes by M×N deep.
//DFS
public class SolutionDFS {
    public int NumIslands(char[][] grid) {
       int count = 0;
        
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1') 
                {
                    count++;
                    ClearConnectedIsLand(grid, i, j);
                }
            }
        }
        return count;
    }
    
    // This function changes all the adjacent 1's to 0 because they all are part of the 
    // same island
    private void ClearConnectedIsLand(char[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0  || j >= grid[i].Length || grid[i][j] == '0') return;
        
        grid[i][j] = '0';
        
        ClearConnectedIsLand(grid, i+1, j);
        ClearConnectedIsLand(grid, i-1, j);
        ClearConnectedIsLand(grid, i, j+1);
        ClearConnectedIsLand(grid, i, j-1);
    }
}

//BFS - Using visited HashSet
public class Solution {
    private static readonly int[][] Directions = 
        new int[][]
            {
                new int[] { -1, 0 }, 
                new int[] { 0, 1 }, 
                new int[] { 1, 0 }, 
                new int[] { 0, -1 }
            };
    
    public int NumIslands(char[][] grid) {
        int maxRow = grid.Length;
        int maxColumn = grid[0].Length;
        
        bool IsLand(Coordinate c) => grid[c.Row][c.Column] == '1';
        
        int result = 0;
        var visited = new HashSet<Coordinate>();
        for (int i = 0; i < maxRow; i++)
        {
            for (int j = 0; j < maxColumn; j++)
            {
                var curCoord = new Coordinate(i, j);
                if (IsLand(curCoord) && !visited.Contains(curCoord))//grid[i][j] == '1'
                {
                    result++;
                    
                    var queue = new Queue<Coordinate>();                    
                    queue.Enqueue(curCoord);
                    visited.Add(curCoord);
                    
                    while (queue.Count > 0)
                    {
                        var curIsland = queue.Dequeue();                        
                        foreach(var island in GetNeighbors(curIsland, maxRow, maxColumn))
                        {
                            if (IsLand(curIsland) && !visited.Contains(island))
                            {
                                queue.Enqueue(island);
                                visited.Add(island);
                            }
                        }
                    }
                }
            }
        }
    
        return result;
    }    
    
    private IEnumerable<Coordinate> GetNeighbors(Coordinate c, int maxRow, int maxColumn)
    {
        foreach (var d in Directions)
        {
            int neighborRow = c.Row + d[0];
            int neighborCol = c.Column + d[1];
            
            if (neighborRow >= 0 && neighborRow < maxRow 
                && neighborCol >= 0 && neighborCol < maxColumn)
            {
                yield return new Coordinate(neighborRow, neighborCol);
            }
        }
    }
    
    public struct Coordinate
    {
        public int Row { get; }
        public int Column { get; }
        
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }        
    }

}

//BFS - Using visited Array
public class SolutionVisitedArray {
    private static readonly int[][] Directions = 
        new int[][]
            {
                new int[] { -1, 0 }, 
                new int[] { 0, 1 }, 
                new int[] { 1, 0 }, 
                new int[] { 0, -1 }
            };
    
    public int NumIslands(char[][] grid) {
        int maxRow = grid.Length;
        int maxColumn = grid[0].Length;
        
        int result = 0;
        //var visited = new HashSet<Coordinate>();
        bool[,] visited = new bool[maxRow, maxColumn];
        for (int i = 0; i < maxRow; i++)
            for (int j = 0; j < maxColumn; j++)
                if (grid[i][j] == '1' && visited[i, j] == false)
                {
                    result++;
                    
                    var queue = new Queue<Coordinate>();                    
                    queue.Enqueue(new Coordinate(i, j));
                    //visited.Add(new Coordinate(i, j));
                    visited[i, j] = true;
                    
                    while (queue.Count > 0)
                    {
                        var curIsland = queue.Dequeue();                        
                        foreach(var island in GetNeighbors(curIsland, maxRow, maxColumn))
                        {
                            if (grid[island.Row][island.Column] != '0' && visited[island.Row, island.Column] == false)
                                //&& !visited.Contains(island))
                            {
                                queue.Enqueue(island);
                                //visited.Add(island);
                                visited[island.Row, island.Column] = true;
                            }
                        }
                    }
                }
        
        return result;
    }
    
    private IEnumerable<Coordinate> GetNeighbors(Coordinate c, int maxRow, int maxColumn)
    {
        foreach (var d in Directions)
        {
            int neighborRow = c.Row + d[0];
            int neighborCol = c.Column + d[1];
            
            if (neighborRow >= 0 && neighborRow < maxRow 
                && neighborCol >= 0 && neighborCol < maxColumn)
            {
                yield return new Coordinate(neighborRow, neighborCol);
            }
        }
    }
    
    public class Coordinate //: IEquatable<Coordinate>
    {
        public int Row { get; }
        public int Column { get; }
        
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
        
        // public bool Equals(Coordinate? other)
        // {
        //     return this.Row == other?.Row && this.Column == other?.Column;
        // }
        
    }

}

//BFS
public class Solution1 {
    private static readonly int[][] Directions = 
        new int[][]
            {
                new int[] { -1, 0 }, 
                new int[] { 0, 1 }, 
                new int[] { 1, 0 }, 
                new int[] { 0, -1 }
            };
    
    public int NumIslands(char[][] grid) {
        int maxRow = grid.Length;
        int maxColumn = grid[0].Length;
        
        int result = 0;
        for (int i = 0; i < maxRow; i++)
            for (int j = 0; j < maxColumn; j++)
                if (grid[i][j] == '1')
                {
                    result++;
                    
                    var queue = new Queue<Coordinate>();                    
                    queue.Enqueue(new Coordinate(i, j));
                    grid[i][j] = '0'; //mark as visited
                    
                    while (queue.Count > 0)
                    {
                        var cur = queue.Dequeue();                        
                        foreach(var cell in GetNeighbors(cur, maxRow, maxColumn))
                        {
                            int nR = cell.Row;
                            int nC = cell.Column;
                            if (grid[nR][nC] != '0')
                            {
                                queue.Enqueue(cell);
                                grid[nR][nC] = '0'; 
                            }
                        }
                    }
                }
        
        return result;
    }
    
    private IEnumerable<Coordinate> GetNeighbors(Coordinate c, int maxRow, int maxColumn)
    {
        foreach (var d in Directions)
        {
            int neighborRow = c.Row + d[0];
            int neighborCol = c.Column + d[1];
            
            if (neighborRow >= 0 && neighborRow < maxRow 
                && neighborCol >= 0 && neighborCol < maxColumn)
            {
                yield return new Coordinate(neighborRow, neighborCol);
            }
        }
    }
    
    public class Coordinate
    {
        public int Row { get; }
        public int Column { get; }
        
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}

//BFS -- Marks Visited as 'N'
public class Solution0 {
    public int NumIslands(char[][] grid) {
        int result = 0;
        int[] dx = new int[] { 1, -1, 0, 0 },
              dy = new int[] { 0, 0, 1, -1 };
        
        for (int i = 0; i < grid.Length; i++)
            for (int j = 0; j < grid[0].Length; j++)
                if (grid[i][j] == '1')
                {
                    result++;
                    
                    Queue<int[]> queue = new Queue<int[]>();
                    
                    queue.Enqueue(new int[] { i, j });
                    grid[i][j] = 'N';
                    
                    while (queue.Count > 0)
                    {
                        int[] cur = queue.Dequeue();
                        
                        for (int k = 0; k < 4; k++)
                        {
                            int newX = cur[0] + dx[k],
                                newY = cur[1] + dy[k];
                            
                            if (newX > -1 && newX < grid.Length && newY > -1 && newY < grid[0].Length && grid[newX][newY] != 'N' && grid[newX][newY] != '0')
                            {
                                queue.Enqueue(new int[] { newX, newY });
                                grid[newX][newY] = 'N';
                            }
                        }
                    }
                }
        
        return result;
    }
}