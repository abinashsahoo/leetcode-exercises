public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var row = new List<int>();        
        var set = new Dictionary<(int, int), int>();
        for(int i = 0; i <= rowIndex; i++)
        {
            int num = GetPascalsTriangleNumber(rowIndex, i, set);
            row.Add(num);
        }        
        return row;        
    }

    private int GetPascalsTriangleNumber(int row, int column, Dictionary<(int, int), int> set)
    {
        if(set.ContainsKey((row, column)))
        {
            return set[(row, column)];
        }
        
        int result = 0;
        if(row == 0 || column == 0 || row == column)
        {
            result = 1;
        }
        else
        {
            result = GetPascalsTriangleNumber(row - 1, column - 1, set) + 
                GetPascalsTriangleNumber(row - 1, column, set);
        }
        
        set.Add((row, column), result);
        return result;
    }
    
//     private int GetPascalsTriangleNumber_NOTE(int row, int column, Dictionary<(int, int), int> set)
//     {
//         if(row == 0 || column == 0 || row == column)
//             return 1;
        
//         //NOTE: Only store the calculated value;
//         int num1 = 0;
//         if(set.ContainsKey((row - 1, column - 1)))
//         {
//             num1 = set[(row - 1, column - 1)];
//         }
//         else
//         {
//             num1 = GetPascalsTriangleNumber(row - 1, column - 1, set);
//             set.Add((row - 1, column - 1), num1);
//         }
        
//         int num2 = 0;
//         if(set.ContainsKey((row - 1, column)))
//         {
//              num2 = set[(row - 1, column)];
//         }
//         else
//         {
//             num2 = GetPascalsTriangleNumber(row - 1, column, set);
//             set.Add((row - 1, column), num2);
//         }
       
//         return num1 + num2;
//     }
}