public class Solution {
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) 
    {        
        //long
        long maxHeight = GetMax(h, horizontalCuts);
        long maxWidth = GetMax(w, verticalCuts);

        const int MOD = (int)1e9 + 7;
        return (int)(maxHeight * maxWidth % MOD);
    }
    
    int GetMax(int h, int[] cuts) 
    {
        Array.Sort(cuts);
        
        int n = cuts.Length;
        int max = Math.Max(cuts[0], h - cuts[n - 1]);
        for (int i = 0; i < n - 1; i++) 
        {
            max = Math.Max(max, cuts[i + 1] - cuts[i]);
        }
        return max;
    }
    
    public int MaxArea1(int h, int w, int[] horizontalCuts, int[] verticalCuts) 
    {
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);
        
        //long
        long maxHeight = horizontalCuts[0];
        for (int i = 0; i < horizontalCuts.Length - 1; i++)
        {
            var height = horizontalCuts[i + 1] - horizontalCuts[i];
            maxHeight = Math.Max(maxHeight, height);
        }
        maxHeight = Math.Max(maxHeight, h - horizontalCuts[horizontalCuts.Length - 1]);
        
        long maxWidth = verticalCuts[0];
        for (int i = 0; i < verticalCuts.Length - 1; i++)
        {
            var width = verticalCuts[i + 1] - verticalCuts[i];
            maxWidth = Math.Max(maxWidth, width);
        }
        maxWidth = Math.Max(maxWidth, w - verticalCuts[verticalCuts.Length - 1]);

        const int MOD = (int)1e9 + 7;        
        //return (int)((maxHeight%MOD)*(maxWidth%MOD)% MOD);
        return (int)(maxHeight * maxWidth % MOD);
    }
}