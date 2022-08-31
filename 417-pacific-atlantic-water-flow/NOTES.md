when we start from the ocean and work backwards, we already know that every cell we visit must be connected to the ocean.
​
** interviewer might ask you to implement the problem recursively instead of iteratively. Recursion must be DFS, not BFS.
​
int[][] DIRECTIONS = new int[][]{{0, 1}, {1, 0}, {-1, 0}, {0, -1}};