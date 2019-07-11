
'''
66. Plus One

Given a non-empty array of digits representing a non-negative integer, plus one to the integer.

The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.

You may assume the integer does not contain any leading zero, except the number 0 itself.

Example 1:

Input: [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Example 2:

Input: [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.
'''

class Solution:
    def plusOne(self, digits):
        digits[len(digits)-1] += 1
        reversed = digits[::-1]

        for i in range(0, len(reversed)):
            if reversed[i] == 10:
                reversed[i] = 0
                if i < (len(reversed) - 1):
                    reversed[i+1] += 1
                else: 
                    reversed.append(1)

        digits = reversed[::-1]
        return digits
        
def main():
    nums = [9, 9, 9]
    ret = Solution().plusOne(nums)
    print(ret)

if __name__ == '__main__':
    main()