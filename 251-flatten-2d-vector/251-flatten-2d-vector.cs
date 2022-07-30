public class Vector2D {
    private int indexX = 0;//
    private int indexY = 0;//
    private int[][] array;
    
    public Vector2D(int[][] vec) {
        array = vec;
    }
    
    public int Next() {        
        if (HasNext(out int x, out int y))         
        {
            indexX = x;
            indexY = y;
            
            return array[indexX][indexY++];//
        }
        
        return -1;//or throw exception
    }
    
    public bool HasNext() {
        return HasNext(out int _, out int _);
    }
    
    private bool HasNext(out int x, out int y) {       
        x = indexX;
        y = indexY;
        
        while(x < array.Length && y == array[x].Length) {  // Move to next available vector; need to skip blank arrays
            x++;
            y = 0;
        }
        return x < array.Length;
    }
}

//["Vector2D","hasNext","next"]
//[[[[],[3]]],[],[]]
//Did not work
public class Vector2D_no {
    int indexX = -1;
    int indexY = -1;
    int[][] array;
    public Vector2D_no(int[][] vec) {
        array = vec;
    }
    
    public int Next() {        
        if (HasNext(out int x, out int y))         
        {
            indexX = x;
            indexY = y;
        }
        
        return array[indexX][indexY];
    }
    
    public bool HasNext() {
        return HasNext(out int x, out int y);
    }
    
    private bool HasNext(out int x, out int y) {       
        x = indexX;
        y = indexY;
        
        if (array.Length == 0) return false;
        if (x == -1 && array[0].Length == 0) return false;
        
        x = x == -1 ? 0 : x;
       
        if (x + 1 < array.Length)// && array[x + 1].Length > 0)
        {
          Console.WriteLine($"x = {x}; y = {y}");
            while (x + 1 < array.Length && array[x + 1].Length == 0)
            {
                Console.WriteLine("vv1");
            
                y = 0;
                x++;
            }
        }
        else
        {
            return false;
        }
        Console.WriteLine($"here; x = {x}; y = {y}");
        return x < array.Length;
    }
}
/**
 * Your Vector2D object will be instantiated and called as such:
 * Vector2D obj = new Vector2D(vec);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */