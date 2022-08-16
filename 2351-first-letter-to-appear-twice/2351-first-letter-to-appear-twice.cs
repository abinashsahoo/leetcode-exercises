public class Solution {
    public char RepeatedCharacter(string s) {
        int resultIndex = int.MaxValue;
        Dictionary<char, (int, int)> set = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (!set.ContainsKey(s[i]))
            {
                set.Add(s[i], (i, 1));
            }
            else
            {
                var (index, count) = set[s[i]];
                set[s[i]] = (index, count + 1);
            }
            
            var (index1, count1) = set[s[i]];
            if(count1 == 2 && resultIndex > index1)
                return s[index1];
                //resultIndex = index1;
        }
        
        // int resultIndex = int.MaxValue;
        // foreach (var (index, count) in set.Values)
        // {
        //     if(count == 2 && resultIndex > index)
        //         resultIndex = index;
        // }
        return s[resultIndex];
    }
}