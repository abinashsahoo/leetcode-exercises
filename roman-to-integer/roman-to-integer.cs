public class Solution {
    public int RomanToInt(string s) {
        Dictionary<char, int> map = new ()
        {
            {'M', 1000},
            {'D', 500},
            {'C', 100},
            {'L', 50},
            {'X', 10},
            {'V', 5},
            {'I', 1}
        };
        
        int result = 0;    
        for (int i = 0; i < s.Length; i++)
        {
            char symbol = s[i];
            char nextSymbol = i + 1 < s.Length ? s[i + 1] : ' ';
            if (nextSymbol != ' ' && map[nextSymbol] > map[symbol])
            {
                result += map[nextSymbol];
                result -= map[symbol];
                i++; //IMP!!!
            }
            else
            {
                result += map[symbol];
            }
        }

        return result;
    }
}