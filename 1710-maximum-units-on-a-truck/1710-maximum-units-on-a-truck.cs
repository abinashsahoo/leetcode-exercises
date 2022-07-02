public class Solution 
{
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        var sortedBoxTypes = boxTypes.OrderByDescending(b => b[1]);
        int count = 0;
        
        foreach(var boxType in sortedBoxTypes)
        {
            int numOfBoxes = boxType[0];
            int numOfUnits = boxType[1];
            
            count += Math.Min(truckSize, numOfBoxes) * numOfUnits;
            truckSize -= Math.Min(truckSize, numOfBoxes);
        }
        
        return count;
    }
    
    public int MaximumUnits1(int[][] boxTypes, int truckSize) {
        int result = 0;
        //Approach 1
        //var sortedBoxes = boxTypes.OrderByDescending(b => b[1]);
        
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