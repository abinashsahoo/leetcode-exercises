//start traversing from the ocean and flip the condition (check for higher height instead of lower height)
public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] matrix) {
        
        List<IList<int>> res = new();
        if(matrix == null || matrix.Length == 0)
            return res;
        
        int m = matrix.Length, n = matrix[0].Length;
        bool[,] pacific = new bool[m,n];
        bool[,] atlantic = new bool[m,n];
        
        // Loop through each cell adjacent to the oceans and start a DFS
        for(int row = 0; row < m; row++)
        {
            DFS(row, 0, matrix, pacific, matrix[row][0]);
            DFS(row, n - 1, matrix, atlantic, matrix[row][n - 1]);
        }

        for(int col = 0; col < n; col++)
        {
            DFS(0 , col, matrix, pacific, matrix[0][col]);
            DFS(m - 1, col, matrix, atlantic, matrix[m - 1][col]);        
        }
        
        // Find the intersection: Find all cells that can reach both oceans
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(pacific[i,j] && atlantic[i,j])
                    res.Add(new List<int>(){i,j});
            }
        }
  
        return res;        
    }
    
    //In LC soln, it's checking before calling DFS; So no need to pass prev value
    //LC soln, uses int[][] DIRECTIONS = new int[][]{{0, 1}, {1, 0}, {-1, 0}, {0, -1}};
    private void DFS(int row, int col, int[][] matrix, bool[,] reach, int prev)
    {
        int m = matrix.Length, n = matrix[0].Length;
        //Check within bounds; has not already been visited; new cell has higher/equal height
        if(row < 0 || row >= m || col < 0 || col >= n || reach[row,col] || matrix[row][col] < prev)
            return;
        
        reach[row,col] = true;
        
        DFS(row, col + 1, matrix, reach, matrix[row][col]);
        DFS(row, col - 1, matrix, reach, matrix[row][col]);
        DFS(row + 1, col, matrix, reach, matrix[row][col]);
        DFS(row - 1, col, matrix, reach, matrix[row][col]);
    }
}