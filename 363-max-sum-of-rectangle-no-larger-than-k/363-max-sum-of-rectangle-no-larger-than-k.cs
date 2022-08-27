public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        if(matrix.Length==0||matrix[0].Length==0)
            return 0;
        int m = matrix.Length, n = matrix[0].Length;
        int[][] psm = new int[m+1][];
        
        for(int i=0; i<psm.Length; i++)
            psm[i] = new int[n+1];
        
        int max = int.MinValue;
        for(int i=1;i<=m;i++)
        {
            for(int j=1;j<=n;j++)
            {
                psm[i][j] = psm[i][j-1]+psm[i-1][j] + matrix[i-1][j-1]-psm[i-1][j-1];
                if(psm[i][j]==k)
                    return k;
                for(int x=0;x<i;x++)
                {
                    for(int y=0;y<j;y++)
                    {
                        int cur=psm[i][j]-psm[i][y]-psm[x][j]+psm[x][y];
                        if(cur<=k&&cur>max)
                        {
                            max=cur;
                        }
                        if(max==k)
                            return max;
                    }
                }
            }
        }
        return max;
    }
}