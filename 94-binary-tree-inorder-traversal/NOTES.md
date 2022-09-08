Time: O(n)
---------------
The time complexity is O(n) because the recursive function is T(n) = 2*T(n/2)+1.
​
Space: O(n)
----------------
The worst case space required is O(n), and in the average case it's O(logn) which is height of the tree, where n is number of nodes.