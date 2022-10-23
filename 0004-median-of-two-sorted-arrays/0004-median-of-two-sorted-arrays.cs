public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // int[] combined = new int[front.Length + back.Length];
        // Array.Copy(front, combined, front.Length);
        // Array.Copy(back, 0, combined, front.Length, back.Length);
        
        int[] newArray = nums1.Concat(nums2).ToArray();
        int p = newArray.Length - 1;
        int p1 = nums1.Length - 1;
        int p2 = nums2.Length - 1;
        
        while (p2 >= 0)
        {
            if (p1 >= 0 && nums1[p1] > nums2[p2])
            {
                newArray[p--] = nums1[p1--];
            }
            else
            {
                newArray[p--] = nums2[p2--];
            }
        }
        
        var (quotient, remainder) = Math.DivRem(newArray.Length, 2);
         if (remainder == 0)//even
         {
             int m1 = quotient - 1;
             return (newArray[quotient] + newArray[m1])/2.0;
         }
        else
        {
            return newArray[quotient];
        }
    }
}