Comparer<(int, string)>.Create((a, b) =>
a.Item1 == b.Item1 ? b.CompareTo(a) : a.Item2.CompareTo(b.Item2))
var grp = words.GroupBy(w => w).ToDictionary(g => g.Key, g => g.ToList());
​
//Constructs the heap using a heapify operation, which is generally faster than
enqueuing individual elements sequentially. O(N)?
​
The main idea is that in the **build_heap** algorithm the actual heapify cost is not O(log n)for all elements.
​
When heapify is called, the running time depends on how far an element might move down in the tree before the process terminates. In other words, it depends on the height of the element in the heap. In the worst case, the element might go down all the way to the leaf level.
​
Let us count the work done level by level.
​
At the bottommost level, there are 2^(h)nodes, but we do not call heapify on any of these, so the work is 0. At the next level there are 2^(h − 1) nodes, and each might move down by 1 level. At the 3rd level from the bottom, there are 2^(h − 2) nodes, and each might move down by 2 levels.
​
As you can see not all heapify operations are O(log n), this is why you are getting O(n).