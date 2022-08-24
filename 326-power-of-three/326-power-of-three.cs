public class Solution {
    public bool IsPowerOfThree(int n) {
        //check if a number is an integer by taking the decimal part (using % 1)
        //Math.Log -> base e
        //Math.Log10 -> base 10
        return (Math.Log10(n) / Math.Log10(3)) % 1 == 0;
    }
}