//Valid: If one of them starts after the other one ends: either e1 <= s2 OR e2 <= s1
//By De Morgan's laws, this means the events conflict when: s2 < e1 AND s1 < e2
public class MyCalendar {
    private List<int[]> _calendar;
    public MyCalendar() {
        _calendar = new List<int[]>();
    }
    
    public bool Book(int start, int end) {
        foreach (var c in _calendar)
        {
            if (c[0] < end && start < c[1])
            {
                return false;
            }
        }
        
        _calendar.Add(new int[] { start, end});
        return true;
    }
}

// public class MyCalendar {
//     private List<int[]> _calendar;
//     public MyCalendar() {
//         _calendar = new List<int[2]>(); //Error: Array size cannot be specified in a variable declaration
//     }
    
//     public bool Book(int start, int end) {
//         // foreach (var event in _calendar) // NOTE: error: event is a keyword and can't be used like this
//         // {
//         //     if (event[0] < end && start < event[1])
//         //     {
//         //         return false;
//         //     }
//         // }
            
//         _calendar.Add(new int[] { start, end});
//         return true;
//     }
// }

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */