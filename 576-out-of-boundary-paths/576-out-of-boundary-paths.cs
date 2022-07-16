public class Solution {
    int MOD = (int)1e9 + 7;
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn) 
    {
        int[][][] memo = CreateMemoizationArray(m, n, maxMove);        
        return FindPaths(m, n, maxMove, startRow, startColumn, memo);
    }
    
    private int FindPaths(int m, int n, int maxMove, int startRow, int startColumn, int[][][] memo) 
    {
        if (m <= 0 || n <= 0) return 0;
        if (startRow < 0 || startRow == m || startColumn < 0 || startColumn == n)
        {
            return 1;
        }
        if (maxMove == 0) return 0; //This should be checked later
        
        if(memo[startRow][startColumn][maxMove] != -1)
        {
            return memo[startRow][startColumn][maxMove];
        }
        
        int paths = FindPaths(m, n, maxMove - 1, startRow - 1, startColumn, memo) % MOD;
        paths = (paths + FindPaths(m, n, maxMove - 1, startRow, startColumn + 1, memo)) % MOD;
        paths = (paths + FindPaths(m, n, maxMove - 1, startRow + 1, startColumn, memo)) % MOD;
        paths = (paths + FindPaths(m, n, maxMove - 1, startRow, startColumn - 1, memo)) % MOD;
        
        memo[startRow][startColumn][maxMove] = paths % MOD;
        return memo[startRow][startColumn][maxMove];
    }
    
    private int[][][] CreateMemoizationArray(int m, int n, int maxMove)
    {
        int[][][] memo = new int[m][][];
        for(int i = 0; i < memo.Length; i++)
        {
            memo[i] = new int[n][];
            
            for (int j = 0; j < memo[i].Length; j++)
            {
                memo[i][j] = new int[maxMove + 1];
                Array.Fill(memo[i][j], -1);
            }
        }
        return memo;        
    }
}