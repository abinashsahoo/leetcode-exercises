//Neetcode
public class Solution {
    public int Trap(int[] height) {
        int result = 0;
        int left = 0, right = height.Length - 1;
        
        int maxLeft = height[left], maxRight = height[right];        
        while(left < right)
        {            
            if(maxLeft < maxRight)
            {                
                left++;
                maxLeft = Math.Max(maxLeft, height[left]);//This trick avoids negative
                result += maxLeft - height[left];
            }
            else
            {
                right--;
                maxRight = Math.Max(maxRight, height[right]);
                result += maxRight - height[right];
            }
        }

        return result;        
    }
}

public class Solution1 {
    public int Trap(int[] height) {
        int result = 0;
        int left = 0, right = height.Length - 1;
        
        int maxLeft = 0, maxRight = 0;        
        while(left < right)
        {            
            if(height[left] < height[right]) //whichever is lower
            {
                if(height[left] >= maxLeft) //This trick also skips negative area
                    maxLeft = height[left];
                else
                    result += (maxLeft - height[left]) * 1;//Area of the current bin
                left++;  
            }
            else
            {
               if(height[right] >= maxRight) 
                   maxRight = height[right];
                else
                    result += (maxRight - height[right]) * 1;//Area of the current bin
                right--;
            }
        }

        return result;        
    }
}

public class SolutionStack {
    public int Trap(int[] height) {
        var stack = new Stack<int>(); 
        int result = 0;
        for (int i = 0; i < height.Length; i++)
        {
            int heightAccountedFor = 0;
            while (stack.Count > 0 && height[i] > height[stack.Peek()])
            {
               // remove previous wall and add its captured water
                int prevIndex = stack.Pop();
                result += (height[prevIndex] - heightAccountedFor) * (i - prevIndex - 1);
                heightAccountedFor = height[prevIndex];
            }
                
            if (stack.Count > 0)
            {
                // there is a wall higher previously, add the captured water between current and previous if any
                result += (height[i] - heightAccountedFor) * (i - stack.Peek() - 1);
            }                
            stack.Push(i);
        }
        return result;
                    
//         int result = 0;
//         int current = 0;
//         var stack = new Stack<int>();        
//         while (current < height.Length)
//         {
//             while (stack.Count > 0 && height[current] > height[stack.Peek()])
//             {
//                 int top = stack.Pop();
//                 if(stack.Count == 0)
//                     break;
                
//                 int distance = current - stack.Peek() - 1;
//                 int boundedHeight = Math.Min(height[current], height[stack.Peek()]) - height[top];
//                 result += distance * boundedHeight;
//             }
//             stack.Push(current++);
//         }
//         return result;
    }
}

public class SolutionDp {
    public int Trap(int[] height) {
        int left = 1;
        int right = height.Length - 2;
        int[] maxLeft = new int[height.Length];
        int[] maxRight = new int[height.Length];
   
        while (left < height.Length)
        {
            maxLeft[left] = Math.Max(maxLeft[left - 1], height[left - 1]);
            maxRight[right] = Math.Max(maxRight[right + 1], height[right + 1]);
            left++;
            right--;
        }
        
        int result = 0;
        for (int i = 0; i < height.Length; i++)
        {
            int water = Math.Min(maxLeft[i], maxRight[i]) - height[i];
            result += water > 0 ? water : 0;
        }
        
        return result;
    }
}

// public class Solution {
//     public int Trap(int[] height) {
//         var maxLeft = new int[height.Length];
//         var maxRight = new int[height.Length];
//         for (int i = 1; i < height.Length; i++)
//         {
//             maxLeft[i] = Math.Max(maxLeft[i - 1], height[i - 1]);
//         }
//         //Console.WriteLine(string.Join(",", maxLeft));
//         for (int i = height.Length - 2; i >= 0; i--)
//         {
//             maxRight[i] = Math.Max(maxRight[i + 1], height[i + 1]);
//         }
//         //Console.WriteLine(string.Join(",", maxRight));
//         int result = 0;
//         for (int i = 1; i < height.Length - 1; i++)
//         {
//             int area = Math.Min(maxLeft[i], maxRight[i]) - height[i];
//             //Console.Write($"{area} ");
//             if (area > 0)
//                 result += area;
//         }
//         return result;
//     }
// }