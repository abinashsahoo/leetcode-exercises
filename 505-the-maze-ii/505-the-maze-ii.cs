//time: O(M∗N∗max(M,N))
//space: O(M*N)
public class Solution {
    public int ShortestDistance(int[][] maze, int[] start, int[] destination) {
        Queue<(int,int)> queue = new();
        
        int m = maze.Length, n = maze[0].Length;
        queue.Enqueue((start[0],start[1]));
        
        int[,] dirs = new int[,]{{0,1},{1,0},{0,-1},{-1,0}};
        int[,] distances = new int[m,n];
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
                distances[i,j] = Int32.MaxValue;
        }
        distances[start[0],start[1]] = 0;
        
        while(queue.Count > 0)
        {
            var curr = queue.Dequeue();
            
            for(int i = 0; i < 4; i++)
            {      
                int steps = distances[curr.Item1, curr.Item2];
                int nextRow = curr.Item1 + dirs[i,0];
                int nextCol = curr.Item2 + dirs[i,1];
               // steps++;
                
                while(nextRow >= 0 && nextRow < m && nextCol >= 0 && nextCol < n && maze[nextRow][nextCol] == 0)
                {
                    nextRow += dirs[i,0];
                    nextCol += dirs[i,1];
                    steps++;
                }
                
                // hit the wall, take one step back
                nextRow -= dirs[i,0];
                nextCol -= dirs[i,1];   
               // steps--;
                
				// only add the positon to the queue if it takes minimal steps to reach here.
                if(steps < distances[nextRow,nextCol])
                {
                    queue.Enqueue((nextRow,nextCol));
                    distances[nextRow,nextCol] = steps;
                }                             
            }
        }
        
        return distances[destination[0],destination[1]] == Int32.MaxValue? -1 : distances[destination[0],destination[1]] ;
    }
}