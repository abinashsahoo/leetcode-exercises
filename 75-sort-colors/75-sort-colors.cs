public class Solution {
    
    public void SortColors(int[] nums) {
        
        int p0 = 0;
        int p2 = nums.Length - 1;
        int current = 0;
        
        while (current <= p2)
        {
            if(nums[current] == 0)
            {
                Swap(nums, p0, current);
                p0++;
                current++;
            }
            else if(nums[current] == 2)
            {
                Swap(nums, current, p2);
                p2--;
            }
            else 
            {
                current++;
            }                
        }
    }
    
    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    
    public void SortColors2(int[] nums) {
        
        var (count0, count1, count2) = GetColorCount(nums); //NOTE: NOT => int (count0, count1, count2)
        SetColors(nums, count0, count1, count2); 
    }

    private (int, int, int) GetColorCount(int[] nums) 
    {
        int count0 = 0;
        int count1 = 0;
        int count2 = 0;
        
        int i = 0;
        while (i < nums.Length)
        {
            int num = nums[i];            
            if(num == 0) 
                count0++;
            else if(num == 1) 
                count1++;
            else 
                count2++;
            
            i++;
        }
        
        return (count0, count1, count2);
    }
    
    private void SetColors(int[] nums, int count0, int count1, int count2) 
    {        
        int i = 0;
        while (i < count0)
        {
            nums[i++] = 0;
        }
        while (i < count0 + count1)
        {
            nums[i++] = 1;
        }
        while (i < nums.Length)
        {
            nums[i++] = 2;
        }
    }
    
    public void SortColors1(int[] nums) {
        Array.Sort(nums);
    }
}