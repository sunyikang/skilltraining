'''
53. Maximum Subarray

Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

Example:

Input: [-2,1,-3,4,-1,2,1,-5,4],
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.
Follow up:

If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
'''


class Solution:
    def maxSubArray(self, nums):
        globalsum, localsum = 0, 0
        if max(nums) < 0:
            return max(nums)
        for num in nums:
            localsum = max(0, localsum+num)
            globalsum = max(localsum, globalsum)
        return globalsum

def main():
    nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
    ret = Solution().maxSubArray(nums)
    print(ret)

if __name__ == '__main__':
    main()
