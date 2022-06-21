//Example 1:
// Input: arr = [1,2,3,4,5], k = 4, x = 3
// Output: [1,2,3,4]

//Example 2:
// Input: arr =[1,1,1,10,10,10], k = 1, x = 9
// Output: [10] //Only sorting by Math.Abs(a - x) will not work

public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {               
        return arr.OrderBy(num => Math.Abs(x - num)).Take(k)
            .OrderBy(a => a).ToList(); // Sort again to have output in ascending order        
    }
}