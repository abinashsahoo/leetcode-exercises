// Time: O(log(min(m,n)))
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int n1 = nums1.Length;
        int n2 = nums2.Length;
        if (n2 < n1) 
            return FindMedianSortedArrays(nums2, nums1); // Make sure num1 is the shorter one.
        
        int lo = 0, hi = n1; // min and max number of elements you can choose from A1
        while (lo <= hi) 
        {
            int cut1 = (lo + hi) >> 1;
            int cut2 = (n1 + n2 + 1)/2 - cut1;

            int left1 = (cut1 == 0) ? int.MinValue : nums1[cut1 - 1];
            int left2 = (cut2 == 0) ? int.MinValue : nums2[cut2 - 1];
            int right1 = (cut1 == n1) ? int.MaxValue : nums1[cut1];
            int right2 = (cut2 == n2) ? int.MaxValue : nums2[cut2];
            
            if(left1 <= right2 && left2 <= right1) //Found the right cut
            {
                if((n1 + n2) % 2 == 0)
                {
                    return (Math.Max(left1, left2) + Math.Min(right1,right2))/2.0;
                } 
                else
                {
                    return Math.Max(left1, left2);                    
                }
            }
            else if(left1 > right2)
            {
                hi = cut1 - 1;// A1's lower half too big; need to move cut1 left.
            }
            else
            {
                lo = cut1 + 1;// move cut1 right)
            }
        }
        return 0;
    }
}

// Time: O (m + n) : e.g., nums1 {4,5,6}, nums2 = { 1,2,3 }
public class Solution2 {
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
//Time: (m + n)log(m + n)
public class Solution1 {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] union = nums1.Concat(nums2).ToArray();
        Array.Sort(union);
        var middle = union.Length/2;
        if(union.Length % 2 != 0)
        {
            return (double)union[middle];
        }
        else
        {
            return (double)(union[middle - 1] + union[middle])/2;
        }
    }
}