public class Solution {
    public int MySqrt(int x) {
        if(x < 2) return x;
        
        int left = 2;
        int right = x/2;
        int mid, divide;
        while(left <= right)
        {
            mid = left + (right - left)/2;
            
//             int num = mid*mid;
            
//             if(num == x)
//                 return mid;
//             else if(num > x)
//                 right = mid - 1;
//             else if (num < x)
//                 left = mid + 1;
            
            divide = x/mid;
            
            if(divide == mid)
                return mid;
            else if (divide < mid)
                right = mid - 1;
            else if (divide > mid)
                left = mid + 1;
        }
        
        return right;
    }
}