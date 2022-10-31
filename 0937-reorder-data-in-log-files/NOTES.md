The LINQ OrderBy(...).ThenBy(...)...ThenBy(...) method chain form a single sort operation by multiple sort keys (using multi key comparer).
​
SortedList<string> - Add: This method is an O(n) operation for unsorted data, where n is Count. It is an O(log n) operation if the new element is added at the end of the list. If insertion causes a resize, the operation is O(n).
​
//QuichSort has worst time complexity of O(N^2)