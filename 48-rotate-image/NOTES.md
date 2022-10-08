Matrix Print
​
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