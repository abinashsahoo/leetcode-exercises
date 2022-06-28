public class Solution {
    
    public double MyPow(double x, int n) {
        int N = n;
        if (N < 0)
        {
            x = 1/x;
            N = -N;
        }
        
        return FastPow(x, N);
    }
    
    private double FastPow(double x, int n) {
        if (n == 0)
        {
            return 1;
        }
        
        double half = FastPow(x, n/2);
        if(n % 2 == 0)
            return half * half;
        else
            return half * half * x;
    }    

}