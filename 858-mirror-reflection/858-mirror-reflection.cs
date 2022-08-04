//https://leetcode.com/problems/mirror-reflection/discuss/146336/Java-solution-with-an-easy-to-understand-explanation
//m * p = n * q
/*
m = even & n = odd => return 0.
m = odd & n = odd => return 1.
m = odd & n = even => return 2.
OR, (max m could be q, max n could be p to satisfy: m*p = n*q)
p = odd, q = even: return 0
p = odd, q = odd: return 1
p = even, q = odd: return 2

So, this problem can be transformed into finding m * p = n * q, where
m = the number of room extension + 1.
n = the number of light reflection + 1.
*/
public class Solution {   
    public int MirrorReflection(int p, int q) {
        int g = gcd(p, q);
        
        p /= g;
        q /= g;
        
        if (q % 2 == 0)
            return 0;
        
        if (p % 2 == 0)
            return 2;
        else 
            return 1;
    }
     
    private static int gcd(int a, int b) {
        while (true) {
            if ((a = a % b) == 0)
                return b;
            
            (a, b) = (b, a);
        }
    }   
}
public class Solution2 {
    public int MirrorReflection(int p, int q) {
        int m = q, n = p;
        //Divide p,q by 2 until at least one odd.
        while(m % 2 == 0 && n % 2 == 0){
            m /= 2;
            n /= 2;
        }
        if (m % 2 == 0 && n % 2 == 1) return 0;
        if (m % 2 == 1 && n % 2 == 1) return 1;
        if (m % 2 == 1 && n % 2 == 0) return 2;
        return -1;
    }
}

public class Solution1 {
    public int MirrorReflection(int p, int q) {
        if (q == 0) return 0;
    
        var height = q;
        while (height < p || height % p != 0) {
            height += q;
        }

        var upFlip = height / p;
        var rightFlip = height / q;

        var topCorner = upFlip % 2 != 0 ? 1 : 0;

        return rightFlip % 2 != 0 ? topCorner : 2;
    }
}