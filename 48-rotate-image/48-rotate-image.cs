public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        for (int row = 0; row <  n/2; row++)
        {
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
        int temp = matrix[cell.Item1][cell.Item2];
        matrix[cell.Item1][cell.Item2] = matrix[anotherCell.Item1][anotherCell.Item2];
        matrix[anotherCell.Item1][anotherCell.Item2] = temp;
    }
}