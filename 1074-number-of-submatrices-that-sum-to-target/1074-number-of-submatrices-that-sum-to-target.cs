public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) {
        int answer = 0;
        var counter = new Dictionary<int, int>();
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                matrix[i][j] += matrix[i][j - 1];
            }
        } 
        
        for (int i = 0; i < matrix[0].Length; i++)
        {
            for (int j = i; j < matrix[0].Length; j++)
            {
                counter.Clear();
                counter.Add(0, 1);
                int cur = 0;
                for (int k = 0; k < matrix.Length; k++) 
                {
                    cur += matrix[k][j] - (i > 0 ? matrix[k][i - 1] : 0);
                    if(counter.ContainsKey(cur - target))
                    {
                        answer += counter[cur - target];                        
                    }
                    
                    if(counter.ContainsKey(cur))
                    {
                        counter[cur]++;                        
                    }
                    else
                    {
                        counter.Add(cur, 1);
                    }
                }
            }
        }
        return answer;
    }
}

//TLE
public class Solution1 {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) {
       int answer = 0;
       for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                for (int rowSize = 1; rowSize <= matrix.Length - i; rowSize++)
                {
                    for (int columnSize = 1; columnSize <= matrix[0].Length - j; columnSize++)
                    {
                        int sum = CalculateSum(matrix, i, j, rowSize, columnSize);
                        if(sum == target)
                        {
                            answer++;
                        }                        
                    }
                }
            }
        }
        return answer;
    }
    
    private int CalculateSum(int[][] matrix, int startX, int startY, int rowSize, int columnSize)
    {
        int sum = 0;
        for (int i = 0; i < rowSize; i++)
        {
            for (int j = 0; j < columnSize; j++)
            {
                sum += matrix[startX + i][startY + j];
            }
        }
        return sum;
    }
}