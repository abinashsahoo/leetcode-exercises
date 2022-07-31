
//Binary Indexed Trees (BIT or Fenwick tree)
//https://leetcode.com/problems/range-sum-query-mutable/discuss/75753/Java-using-Binary-Indexed-Tree-with-clear-explanation
public class NumArray {
    int[] arr;
    int[] BIT;
    int n;

    public NumArray(int[] nums) {
        arr = nums;
        
        n = nums.Length;
        BIT = new int[n + 1];
        for(int i = 0; i < n; i++)
            init(i, nums[i]);
    }
    
    public void init(int i, int val)
    {
        i++;
        while(i <= n)
        {
            BIT[i] += val;
            i += (i & -i);
        }
    }
    
    public void Update(int i, int val) {
        int diff = val - arr[i];
        arr[i] = val;
        init(i, diff);
    }
    
    private int GetSum(int i)
    {
        int sum = 0;
        i++;
        while(i > 0)
        {
            sum += BIT[i];
            i -= (i & -i);
        }
        return sum;
    }
    
    public int SumRange(int left, int right) {
        return GetSum(right) - GetSum(left - 1);
    }
}

// Incorrect!  The sum is associated with index that needs to be stored
public class NumArray2 {
    private int[] _array;
    private int _sum = int.MinValue;//
    public NumArray2(int[] nums) {
        _array = nums;
    }
    
    public void Update(int index, int val) {
        var difference = val - _array[index]; //remove old, add new : (sum - old + new)
        _array[index] = val;
        if (_sum != int.MinValue)
        {
            _sum += difference;            
        }
    }
    
    public int SumRange(int left, int right) {
        if (_sum == int.MinValue)
        { 
            _sum = 0;//
            for (int i = left; i <= right; i++)
            {
                _sum += _array[i];
            }
        }
        return _sum;
    }
}

//TLE
public class NumArray1 {
    private int[] _array;
    public NumArray1(int[] nums) {
        _array = nums;
    }
    
    public void Update(int index, int val) {
        _array[index] = val;
    }
    
    public int SumRange(int left, int right) {
        int sum = 0;
        for (int i = left; i <= right; i++)
        {
            sum += _array[i];
        }
        return sum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */