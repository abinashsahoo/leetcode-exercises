public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {        
        var colSet = new HashSet<int>();
        var diagSet = new HashSet<int>();//r - c
        var antiDiagSet = new HashSet<int>();//r + c
        
        var board = new char?[n, n];
        var result = new List<IList<string>>();        
        void Backtrack(int row)
        {
            if (row == n)
            {                
                result.Add(GetResult(board).ToList());
                return;
            }
            
            for (int col = 0; col < n; col++)
            {
                if (CanPlace(row, col))
                {
                    SetState(row, col);
                    Backtrack(row + 1);
                    ResetState(row, col);
                }
            }
        }
               
        bool CanPlace (int row, int col) => 
            (!colSet.Contains(col) && !diagSet.Contains(row - col) && !antiDiagSet.Contains(row + col));
        
        void SetState(int row, int col)
        {
            diagSet.Add(row - col);
            antiDiagSet.Add(row + col);
            colSet.Add(col);
            board[row, col] = 'Q';
        }
        
        void ResetState(int row, int col)
        {
            colSet.Remove(col);
            diagSet.Remove(row - col);
            antiDiagSet.Remove(row + col);
            board[row, col] = null; 
        }
        
        Backtrack(0);
        return result;
    }
    
    IEnumerable<string> GetResult(char?[,] board)
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            yield return string.Join(",", new string(GetRow().ToArray()));//ToArray !Important
            IEnumerable<char> GetRow()
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    yield return board[row, col] ?? '.';
                }
            }
        }
    }
                
//     IEnumerable<string> GetResult(char?[,] board)
//     {
//         for (int row = 0; row < board.GetLength(0); row++)
//         {                  
//             yield return string.Join(",", new string(GetRow(board, row).ToArray()));
//         }
//     }
    
//     IEnumerable<char> GetRow(char?[,] board, int row)
//     {
//         for (int col = 0; col < board.GetLength(1); col++)
//         {
//             yield return board[row, col] ?? '.';
//         }
//     }
}