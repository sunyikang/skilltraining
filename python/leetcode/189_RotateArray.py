"""
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
"""

"""
Solution:
    [1, 2, 3, 4, 5, 6, 7, 8]
            [1, 2, 3, 4, 5     => nums[0, 8 - 3] 
    6, 7, 8]                    => nums[8 - 3, 8] 
"""




from typing import List
class Solution:
    def rotate(self, nums: List[int], k: int):
        """Do not return anything, modify nums in-place instead"""
        length = len(nums)
        scope = length - k

        # https://stackoverflow.com/questions/22054698/python-modifying-list-inside-a-function
        # If you assign something to the variable list_arg, it will from then on
        # point to the new value. The value it pointed to before that assignment
        # (your original list) will stay unchanged.
        #
        # If you, instead, assign something to elements of that list, this will
        # change the original list:
        #
        # list_arg[:] = list(a)
        print(nums[scope:length])
        print(nums[0:scope])
        nums[:] = nums[scope:length] + nums[0:scope]
        print(nums)


nums = [1, 2, 3, 4, 5, 6, 7, 8]
Solution().rotate(nums, 3)

nums = [1, 2]
Solution().rotate(nums, 1)
