/*
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
*/

/*
Solution:

    find leaf in a layer of node, if cannot find, go to next layer
*/

#include <iostream>
#include <queue>
using namespace std;


struct TreeNode {
    // Definition for a binary tree node
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};


class Solution {
public:
    int minDepth(TreeNode* root) {
        if (root == NULL) {
            return 0;
        }

        int count = 0;
        bool hasLeaf = false;
        queue<TreeNode*> nodes;
        nodes.push(root);

        while(!hasLeaf) {
            hasLeaf = findLeaf(nodes);
            count++;
        }

        return count;
    }

private:
    bool findLeaf(queue<TreeNode*>& nodes) {
        int length = nodes.size();

        for (int i = 0; i < length; i++) {
            auto node = nodes.front();
            nodes.pop();

            if (node->left == NULL && node->right == NULL) {
                return true;
            }

            if (node->left != NULL) {
                nodes.push(node->left);
            }

            if (node->right != NULL) {
                nodes.push(node->right);
            }
        }

        return false;
    }
};


int main() {
    auto solution = Solution();

    TreeNode* root = new TreeNode(1);
    root->left = new TreeNode(2);
    root->right = new TreeNode(4);
    root->left->right = new TreeNode(3);
    auto minDepth = solution.minDepth(root);
    cout << minDepth << "\n";
}
