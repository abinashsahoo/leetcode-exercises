Instead of this:
if(root.left != null)
{
isValidBST = root.val > root.left.val;
}
Can't write this : isValidBST = root.val > root.left?.val;
because if left is null the result would be false; w