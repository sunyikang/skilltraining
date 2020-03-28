"""
Requirement:

    https://leetcode.com/problems/minimum-depth-of-binary-tree/

    Given a binary tree, find its minimum depth.

    The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

    Note: A leaf is a node with no children.

    Example:

    Given binary tree [3,9,20,null,null,15,7],

        3
    / \
    9  20
        /  \
    15   7
    return its minimum depth = 2.
"""

"""
Solution:

"""


class TreeNode:
    """Definition for a binary tree node."""

    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

class Solution:
    def minDepth(self, root: TreeNode) -> int:
        if root is None:
            return 0

        count = 0
        hasLeaf = False
        nodes = [root]

        while not hasLeaf:
            hasLeaf, nodes = self.findLeaf(nodes)
            count += 1

        return count

    def findLeaf(self, nodes):
        newNodes = []

        for node in nodes:
            if node.left is None and node.right is None:
                return True, []

            if node.left is not None:
                newNodes.append(node.left)

            if node.right is not None:
                newNodes.append(node.right)

        return False, newNodes


root = TreeNode(4)
root.left = TreeNode(5)
root.left.left = TreeNode(7)
x = Solution().minDepth(root)
print(x)
