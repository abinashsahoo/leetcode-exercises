//Error: Array size cannot be specified in a variable declaration
List<int[]> calendar = new List<int[2]>(); //Incorrect
List<int[]> calendar = new List<int[]>(); //Correct
​
foreach (var event in _calendar) // NOTE: error: event is a keyword can't be used as variable
​
//Valid: If one of them starts after the other one ends: either e1 <= s2 OR e2 <= s1
//By **De Morgan's laws**, this means the events conflict when: s2 < e1 AND s1 < e2