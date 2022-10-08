// clockwise and anti-clockwise?

public class Solution {
    public void Rotate(int[][] matrix) {
        Transpose(matrix);
        Reflect(matrix);
        
        Print(matrix);
    }
    
    private void Transpose (int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                Swap ((i, j), (j, i), matrix);
                
                // int tmp = matrix[j][i];
                // matrix[j][i] = matrix[i][j];
                // matrix[i][j] = tmp;
            }
        }
    }
    
        private void Reflect (int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            Array.Reverse(matrix[i]);
        }
    }
    
    private void Reflect1(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {            
            for (int j = 0; j < n/2; j++)
            {
                Swap ((i, j), (i, n - j - 1), matrix);
                
                // int tmp = matrix[i][j];
                // matrix[i][j] = matrix[i][n - j - 1];
                // matrix[i][n - j - 1] = tmp;
            }
        }
    }
    
    private void Swap ((int, int) cell, (int, int) anotherCell, int[][] matrix)
    {
        //Console.WriteLine($"({cell.Item1},{cell.Item2}) <-> ({anotherCell.Item1},{anotherCell.Item2})");
        int temp = matrix[cell.Item1][cell.Item2];
        matrix[cell.Item1][cell.Item2] = matrix[anotherCell.Item1][anotherCell.Item2];
        matrix[anotherCell.Item1][anotherCell.Item2] = temp;
    }
    
    private void Print(int[][] matrix)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                Console.Write($"{matrix[row][col], -3}");
            }

            Console.WriteLine();
        }
    }
}

public class Solution2 {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        for (int row = 0; row <  n/2; row++)
        {
            Console.WriteLine($"row = {row}");
            for (int col = row; col < n - row - 1; col++)
            {
                Swap((row, col), (col, n - 1 - row), matrix);
                Swap((row, col), (n - 1 - row, n - 1 - col), matrix);
                Swap((row, col), (n - 1 - col, row), matrix);
            }
        }
    }
    
    private void Swap ((int, int) cell, (int, int) anotherCell, int[][] matrix)
    {
        Console.WriteLine($"({cell.Item1},{cell.Item2}) <-> ({anotherCell.Item1},{anotherCell.Item2})");
        int temp = matrix[cell.Item1][cell.Item2];
        matrix[cell.Item1][cell.Item2] = matrix[anotherCell.Item1][anotherCell.Item2];
        matrix[anotherCell.Item1][anotherCell.Item2] = temp;
    }
}


public class Solution1 {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        for (int row = 0; row <  n/2; row++)
        {
            Console.WriteLine($"row = {row}");
            for (int col = row; col < n - row - 1; col++)
            {
                Swap((row, col), (col, n - 1 - row), matrix);
                Swap((row, col), (n - 1 - row, n - 1 - col), matrix);
                Swap((row, col), (n - 1 - col, row), matrix);
            }
        }
    }
    
    private void Swap ((int, int) cell, (int, int) anotherCell, int[][] matrix)
    {
        Console.WriteLine($"({cell.Item1},{cell.Item2}) <-> ({anotherCell.Item1},{anotherCell.Item2})");
        int temp = matrix[cell.Item1][cell.Item2];
        matrix[cell.Item1][cell.Item2] = matrix[anotherCell.Item1][anotherCell.Item2];
        matrix[anotherCell.Item1][anotherCell.Item2] = temp;
    }
}

public class Solution0 {
    public void Rotate(int[][] matrix) {
        
        int n = matrix.Length;
        int[,] A = new int[n,n];
        
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                A[row,col] = matrix[row][col];
            }
        }
        
        //Array.Reverse(A); //Does not work for 2D array
        Print(A);
    }
    
    private void Print(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col], -3}");
            }

            Console.WriteLine();
        }
    }
}

