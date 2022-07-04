//[1,3,2,2,1]
//[1,2,87,87,87,2,1]
public class Solution {
    public int Candy(int[] ratings) {
        
        if (ratings.Length <=1) return 1;
        
        int[] candy = new int[ratings.Length];
        candy[0] = 1;
        for (int i = 1; i < ratings.Length; i++)
        {
            candy[i] = ratings[i] > ratings[i - 1] ? 
                            candy[i - 1] + 1 :
                            1;
        }
        
        for (int i = candy.Length - 1; i > 0; i--)
        {
            if(ratings[i - 1] > ratings[i] && candy[i - 1] <= candy[i])
            {
                candy[i - 1] = candy[i] + 1;
            }
        }
        
        return candy.Sum(c => c);
    }
}