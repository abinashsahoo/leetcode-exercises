public class Solution {
    public int Fib(int n) {
        if(n < 0 || n > 30) 
            throw new ArgumentOutOfRangeException(nameof(n));
        
        if(n <=1) return n;
        
        int previous1 = 1;
        int previous2 = 0;
        int result = 0;
        for (int i = 2; i <= n; i++) {
            result = previous1 + previous2;
            previous2 = previous1;
            previous1 = result;
        }
        
        return result;
    }
}