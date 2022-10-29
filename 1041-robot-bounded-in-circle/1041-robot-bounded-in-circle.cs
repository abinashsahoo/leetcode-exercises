public class Solution {
    public bool IsRobotBounded(string instructions) {
        int x = 0, y = 0;
        int dx = 0, dy = 1;//delta/step -> North facing
       
        foreach (var ins in instructions)
        {
            if (ins == 'L')
            {
                (dx, dy) = (-dy, dx);
                
                // var temp = dx;
                // dx = -dy;
                // dy = temp;
            }
            else if (ins == 'R')
            {
                (dx, dy) = (dy, -dx);
                
                // var temp = -dx;
                // dx = dy;
                // dy = temp;
            }
            else
            {
                x = x + dx;
                y = y + dy;
            }
        }
        return (x == 0 && y == 0) || !(dx == 0 && dy == 1);//Origin or not north
    }
}