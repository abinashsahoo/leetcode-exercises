using System.Text.RegularExpressions;

public class Solution {
    public int[] MovesToStamp(string stamp, string target) {
     var result = new Stack<int>();
     
	    // (?!___..._)(a|_)...(c|_) pattern
        var regex = new Regex("(?!" + new string('_', stamp.Length) + ")" + string.Concat(stamp.Select(c => $"({c}|_)")));
        bool agenda = true; 
        while (agenda) 
        {
            agenda = false;
            
            target = regex.Replace(target, m => {
                agenda = true;
                
                result.Push(m.Index);
                
                return new string('_', stamp.Length);
            });
        }
        
        return target.All(c => c == '_') ?  result.ToArray() : new int[0];   
    }
}