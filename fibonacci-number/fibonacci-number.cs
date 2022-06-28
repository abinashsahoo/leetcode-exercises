public class Solution {
    public int Fib(int n) {
        if(n < 0 || n > 30) 
            throw new ArgumentOutOfRangeException(nameof(n));
        
        if(n <=1) return n;
        
        int previous1 = 0;
        int previous2 = 1;
        int result = 1;
        for (int i = 2; i <= n; i++) {
            result = previous2 + previous1;
            previous1 = previous2;
            previous2 = result;
        }
        
        return result;
    }
}