public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        int result = 0;
        var sortedList = boxTypes.OrderByDescending(b => b[1]);
        foreach (var boxType in sortedList)
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