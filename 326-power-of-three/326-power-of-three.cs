//129140163
public class Solution {
    public bool IsPowerOfThree(int n) {
        //check if a number is an integer by taking the decimal part (using % 1)
        //Math.Log -> base e
        //Math.Log10 -> base 10
        //return (Math.Log10(n) / Math.Log10(3)) % 1 == 0;
        //NOTE: Epsilon Did not work in c#?
        Console.WriteLine(double.Epsilon);
         Console.WriteLine((Math.Log10(n) / Math.Log10(3)));
        Console.WriteLine(((Math.Log(n) / Math.Log(3))));
        return ((Math.Log(n) / Math.Log(3)) + 0.00000000000001d) % 1 <= 2 * 0.00000000000001d;
    }
}