/*
Requirement:
    https://leetcode.com/problems/rotate-array/

    Given an array, rotate the array to the right by k steps, where k is non-negative.

    Example 1:

    Input: [1,2,3,4,5,6,7] and k = 3
    Output: [5,6,7,1,2,3,4]
    Explanation:
    rotate 1 steps to the right: [7,1,2,3,4,5,6]
    rotate 2 steps to the right: [6,7,1,2,3,4,5]
    rotate 3 steps to the right: [5,6,7,1,2,3,4]
    Example 2:

    Input: [-1,-100,3,99] and k = 2
    Output: [3,99,-1,-100]
    Explanation: 
    rotate 1 steps to the right: [99,-1,-100,3]
    rotate 2 steps to the right: [3,99,-1,-100]
    Note:

    Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
    Could you do it in-place with O(1) extra space?

Solution:
    [1, 2, 3, 4, 5, 6, 7, 8]
            [1, 2, 3, 4, 5     => nums[0, 8 - 3] 
    6, 7, 8]                    => nums[8 - 3, 8] 
*/

#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    void rotate(vector<int>& nums, int k) {
        int length = nums.size();
        k = k % length;
        int scope = length - k;
        auto nums_left = vector<int>(nums.begin() + scope, nums.end());
        auto nums_right = vector<int>(nums.begin(), nums.begin() + scope);
        nums_left.insert(nums_left.end(), nums_right.begin(), nums_right.end() );
        nums = nums_left;
    }
};

void print(const vector<int> input) {
    for (auto const&one : input) {
        cout << one << " ";
    }
}

int main() {
    vector<int> nums {1, 2, 3, 4, 5, 6, 7, 8};
    Solution solution;
    solution.rotate(nums, 3);
    print(nums);
    cout << "\n";
}

