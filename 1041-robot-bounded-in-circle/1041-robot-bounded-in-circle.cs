public class Solution1 {
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

public class Solution {
    enum Direction {
        NORTH,
        SOUTH,
        WEST,
        EAST
    }
    
    public bool IsRobotBounded(string instructions) {
        // TODO validation if no constrains
        int x = 0, y = 0;
        Direction direction = Direction.NORTH;
        
        foreach (char instruction in instructions) {
            if (instruction == 'G') {
                switch (direction) {
                    case Direction.NORTH:
                        y++;
                        break;
                    case Direction.SOUTH:
                        y--;
                        break;
                    case Direction.WEST:
                        x--;
                        break;
                    case Direction.EAST:
                        x++;
                        break;
                }
            }
            else if (instruction == 'L') 
            {
                switch (direction) {
                    case Direction.NORTH:
                        direction = Direction.WEST;
                        break;
                    case Direction.SOUTH:
                        direction = Direction.EAST;
                        break;
                    case Direction.WEST:
                        direction = Direction.SOUTH;
                        break;
                    case Direction.EAST:
                        direction = Direction.NORTH;
                        break;
                }
            } else if (instruction == 'R') {
                switch (direction) {
                    case Direction.NORTH:
                        direction = Direction.EAST;
                        break;
                    case Direction.SOUTH:
                        direction = Direction.WEST;
                        break;
                    case Direction.WEST:
                        direction = Direction.NORTH;
                        break;
                    case Direction.EAST:
                        direction = Direction.SOUTH;
                        break;
                }
            }
        }
        
        if (x == 0 && y == 0) { return true; }
        if (direction == Direction.NORTH) { return false; }
        
        return true;
     }

}