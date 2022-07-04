//[1,3,2,2,1]
//[1,2,87,87,87,2,1]
public class Solution 
{
    public int Candy(int[] ratings) 
    {        
        if (ratings.Length <=1) return 1;
        
        int[] candies = new int[ratings.Length];
        
        //In 1st pass give at least 1 candy to everyone; 1 more if the rating is higher than the prev
        candies[0] = 1;// at least 1
        for (int i = 1; i < ratings.Length; i++)
        {
            candies[i] = ratings[i] > ratings[i - 1] ? 
                            candies[i - 1] + 1 :
                            1; // at least 1
        }
        
        //In this pass (from end), allocate 1 more candy if needed to satisfy rule:2 
        //example case: [1,2,87,87,87,2,1]
        for (int i = candies.Length - 1; i > 0; i--)
        {
            if(ratings[i - 1] > ratings[i] && candies[i - 1] <= candies[i])
            {
                candies[i - 1] = candies[i] + 1;
            }
        }
        
        return candies.Sum();
    }
}