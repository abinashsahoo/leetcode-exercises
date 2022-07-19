public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var triangle = new List<IList<int>>();
        var row = new List<int>();
        row.Add(1);
        triangle.Add(row);
        
        for(int i=1; i<numRows; i++) {
            row = new List<int>();
            var prevRow = triangle[i-1];
            
            //first item is always 1
            row.Add(1);
            
            for(int k=1; k<i; k++) {
                row.Add(prevRow[k-1] + prevRow[k]);
            }
            
            //last item is always 1
            row.Add(1);
            
            triangle.Add(row);
        }
        
        return triangle;
    }
}