public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        int result = 0;
        //Approach 1
        //var sortedList = boxTypes.OrderByDescending(b => b[1]);
        
        //Approach 2
        //Array.Sort(boxTypes, (a, b) =>  b[1] - a[1]);
        
        //Approach 3
        var comparer = Comparer<int>.Default;
        Array.Sort(boxTypes, (a, b) =>  comparer.Compare(b[1], a[1]));
        
        foreach (var boxType in boxTypes)
        {
            int numOfBoxes = boxType[0];
            int numOfUnits = boxType[1];
            
            if(numOfBoxes < truckSize)
            {
                result += numOfBoxes * numOfUnits;
                truckSize -= numOfBoxes;
            }
            else
            {
                result += truckSize * numOfUnits;
                truckSize -= truckSize;
                return result;
            }
        }
        return result;
    }
}