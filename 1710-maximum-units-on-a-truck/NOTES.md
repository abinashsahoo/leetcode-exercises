Sort array:
​
//Approach 1
//var sortedList = boxTypes.OrderByDescending(b => b[1]);
​
//Approach 2
//Array.Sort(boxTypes, (a, b) =>  b[1] - a[1]);
​
//Approach 3
var comparer = Comparer<int>.Default;
Array.Sort(boxTypes, (a, b) =>  comparer.Compare(b[1], a[1]));