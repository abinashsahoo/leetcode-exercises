//Note that all these algorithms retuens kth largest element in the sorted order, not the kth distinct element.

//Interesting way to devide: Though it's O(N) space
//Quickselect
public class Solution {

    public int FindKthLargest(int[] nums, int k) {        
        // var rand = new Random();
        // int pivotIndex = rand.Next(nums.Length - 1);
        // int pivot = nums[pivotIndex];
        int pivot = nums[0];//This would also work
        
        var leftPart =  nums.Where(n => n > pivot).ToArray();//O(n)
        var midPart  =  nums.Where(n => n == pivot).ToArray();//O(n); works with duplicates!
        var rightPart = nums.Where(n => n < pivot).ToArray();//O(n)
        
        int left = leftPart.Length;
        int mid = midPart.Length; 
                
        if (k <= left)
            return FindKthLargest(leftPart, k);
        else if (k > left + mid)
            return FindKthLargest(rightPart, k - left - mid);
        else
            return midPart[0];
    }
}

//Quickselect
public class Solution1 {
    
    //NOTE: Kth largest means (k - 1) th index item
    public int FindKthLargest(int[] nums, int k) {
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            int pivotIndex = Partition(nums, left, right);
            if (pivotIndex == k - 1)
            {
                return nums[pivotIndex];
            }
            else if (pivotIndex < k - 1)
            {
                left = pivotIndex + 1;
            }
            else
            {
                right = pivotIndex - 1;
            }
        }
        return nums[k - 1];
    }
    
    private int Partition(int[] nums, int left, int right)
    {
        //var rand = new Random();
        //int pivotIndex = rand.Next(left, right);
        int pivot = nums[left];
        while (left < right)
        {
            while (left < right && nums[right] <= pivot) right--;
                nums[left] = nums[right];
            while (left < right && nums[left] >= pivot) left++;
                nums[right] = nums[left];
        }
        nums[left] = pivot;
        return left;
    }
}

//MinHeap
// O(Nlogk) -heap of size k, N times that means O(Nlogk) 
//Space: O(k)
public class SolutionMinHeap {
    //NOTE: Kth largest means (k - 1) th index item
    public int FindKthLargest(int[] nums, int k) {
        var pq = new PriorityQueue<int, int>();
        foreach (int n in nums)
        {
            pq.Enqueue(n, n);
            if (pq.Count > k)
                pq.Dequeue();
        }
        return pq.Peek();
    }
}