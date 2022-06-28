//nums1 = [0], m = 0, nums2 = [1], n = 1
public class Solution {
    
    public void Merge(int[] nums1, int m, int[] nums2, int n) 
    {
        int p1 = m - 1;
        int p2 = n - 1;
        int p3 = m + n - 1;
        
        while (p1 >= 0 && p2 >=0)
        {
            //NOTE: this is not really needed; 
            // if(nums1[p1] == nums2[p2])
            // {
            //     nums1[p3--] = nums1[p1--];
            //     nums1[p3--] = nums2[p2--];
            // }
            // else 
            if(nums1[p1] > nums2[p2])
            {
                nums1[p3--] = nums1[p1--];
            }
            else
            {
                nums1[p3--] = nums2[p2--];
            }
        }
        
        while (p1 >=0)
        {
            nums1[p3--] = nums1[p1--];
        }
        
        while (p2 >=0)
        {
            nums1[p3--] = nums2[p2--];
        }
    }
}