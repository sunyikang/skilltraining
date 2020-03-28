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
    def move_next_pos(self, nums, left):
        for i in range(left, len(nums)):
            if nums[i] > 0:
                return i

    def maxSubArray(self, nums):
        max_sum = 0
        left = 0
        right = 0
        next_pos_index = 0
        sub_sum = 0

        # special#1: if all negative and 0 return max num
        max_num = max(nums)
        if max_num <= 0:
            return max_num

        for left in range(0, len(nums)):
            right = left + 1
            sub_sum = sum(nums[left:right])

            # find sub_sum
            while sub_sum > 0:
                if sub_sum > max_sum:
                    max_sum = sub_sum
                else:
                    if right == len(nums):
                        break
                    else:
                        right += 1
                        sub_sum = sum(nums[left:right])

            # left move to next positive number
            left = self.move_next_pos(nums, left)

        return max_sum
        
def main():
    nums = [-2,1,-3,4,-1,2,1,-5,4]
    ret = Solution().maxSubArray(nums)
    print(ret)

if __name__ == '__main__':
    main()