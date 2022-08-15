public class SparseVector {    
    public Dictionary<int, int> Vector { get; private set; }
    public SparseVector(int[] nums) {
        Vector = new();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                Vector.Add(i, nums[i]);
            }
        }
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) {
        int result = 0;
        foreach (int index in Vector.Keys)
        {
            if (vec.Vector.ContainsKey(index))
            {
                result +=  Vector[index] * vec.Vector[index];
            }
        }
        return result;
    }
}

public class SparseVector2 {    
    public Dictionary<int, int> Vector { get; private set; }
    public int Length { get; private set; }
    public SparseVector2(int[] nums) {
        Length = nums.Length;
        Vector = new();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                Vector.Add(i, nums[i]);
            }
        }
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector2 vec) {
        int result = 0;
        for (int i = 0; i < vec.Length; i++) //NOTE: We don't really need to traverse n times
        {
            int val1 = Vector.ContainsKey(i) ? Vector[i] : 0;
            int val2 = vec.Vector.ContainsKey(i) ? vec.Vector[i] : 0;
            result +=  val1 * val2;
        }
        return result;
    }
}

// NOTE: Space complexity: O(1) for constructing the sparse vector as we simply save a reference to the input array and O(1) for calculating the dot product.

public class SparseVector1 {    
    private int[] array;

    public SparseVector1(int[] nums) {
        array = nums;
    }

    public int DotProduct(SparseVector1 vec) {
        int result = 0;

        for (int i = 0; i < array.Length; i++) {
            result += array[i] * vec.array[i];
        }
        return result;
    }   
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);