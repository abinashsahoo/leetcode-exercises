
//Backtracking - TLE; Added seen
//Time O(E + N^2) : One single line; n + n - 1, n - 1 = N(N + 1)/2
// O(E +3⋅V) = O(E + V) => E: number of dependencies; V: Number of courses
public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        IDictionary<int, ICollection<int>> courseDict = CreateCourseDictionary(prerequisites); 
        var path = new bool[numCourses];//visited during a traversal //NOTE: it has to be declared here before calling "IsNonCyclic" method
        var seen = new Dictionary<int, bool>();
        for (int currCourse = 0; currCourse < numCourses; currCourse++)
        {
            if(!IsNonCyclic(currCourse))
                return false;
        }
        return true;
        

        bool IsNonCyclic(int currCourse)
        {
            if (path[currCourse])//detects a cycle
            {
                return false;
            }
            
            // no following courses; we are good!
            if (!courseDict.ContainsKey(currCourse)) //e.g., [[1, 0]] => 1 won't exist
            {
                return true;
            }
            
            if (seen.ContainsKey(currCourse))
                return seen[currCourse];
            
            path[currCourse] = true;
            bool result = false;
            foreach (var c in courseDict[currCourse])
            {
                result = IsNonCyclic(c);
                if(!result) // NOTE: We can't return here; we have to reset the status
                    break;
            }
            path[currCourse] = false;
            seen.Add(currCourse, result);
            return result;
        }
    }
    
    private IDictionary<int, ICollection<int>> CreateCourseDictionary(int[][] prerequisites)
    {
        var courseDict = new Dictionary<int, ICollection<int>>();
        foreach (var c in prerequisites)
        {
            //c[0] depends on c[1]
            var currCourse  = c[1];
            var nextCourse = c[0];
            if (!courseDict.ContainsKey(currCourse))
            {
                courseDict.Add(currCourse, new List<int>());
            }
            courseDict[currCourse].Add(nextCourse);
        }
        return courseDict;
    }
}