//Quickselect
public class Solution {
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