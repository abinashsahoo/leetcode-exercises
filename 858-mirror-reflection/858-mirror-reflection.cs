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
*/
public class Solution {
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