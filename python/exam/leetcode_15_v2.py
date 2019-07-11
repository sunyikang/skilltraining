'''
15. 3 Sum

Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note:

The solution set must not contain duplicate triplets.

Example:

Given array nums = [-1, 0, 1, 2, -1, -4],

A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]
'''
from collections import defaultdict

class Solution:
    def threeSum(self, nums):

        '''
        main idea is the split 3 dimentions problem into 2 dimentions by using dictionary
        drop the complexity from O^3 to O^2
        
        step forwards divide the list to half - half 
        drop the complexity by O^2 / (2 x 2)
        '''

        dict = defaultdict(int)
        for num in nums:
            dict[num] += 1
        
        ret = []
        if 0 in dict and dict[0] > 2:
          ret.append([0,0,0])

        keys = dict.keys()        
        pos = sorted([k for k in keys if k > 0])
        neg = sorted([k for k in keys if k < 0])

        for p in pos:
            for n in neg: 

                other = - (p + n)

                if other in keys:
                    if other == p and dict[p] > 1:
                        ret.append([n, p, p])
                    elif other == n and dict[n] > 1:
                        ret.append([n, n, p])
                    elif n < other < p:
                        ret.append([n, other, p])

        return ret

def main():
    nums = [-1, 0, 1, 3, 2, -3, -1, -4]
    ret = Solution().threeSum(nums)
    print(ret)

if __name__ == '__main__':
    main()