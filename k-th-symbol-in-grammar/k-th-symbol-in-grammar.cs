public class Solution {
    //Time O(n); Space: O(n)    
    public int KthGrammar(int n, int k) {
        if (n == 1) return 0;
        
        int parent = KthGrammar(n-1, (k+1)/2);
        if (k % 2 == 0)
        {
            return parent == 0 ? 1 : 0;
        }
        else
        {
            return parent;
        }        
    }
    
    public int KthGrammar2(int n, int k) {
        if (n == 1) return 0;
        
        if (k % 2 == 0)
        {
            return KthGrammar2(n-1, k/2) == 0 ? 1 : 0;
        }
        else
        {
            return KthGrammar2(n-1, (k+1)/2);
        }        
    }
    
//Brute force    
    public int KthGrammar1(int n, int k) {
        string newString = KthGrammar1(n);
        return Convert.ToInt32(newString[k - 1].ToString());
    }
    
    private string KthGrammar1(int n) {
        if (n == 1) return "0";
        
        string prevString = KthGrammar1(--n);
        
        string newString = "";
        foreach (var c in prevString)
        {
            newString += c == '0' ? "01" : "10";                
        }
   
        return newString;
    }
}