
'''
67. Add Binary

Given two binary strings, return their sum (also a binary string).

The input strings are both non-empty and contains only characters 1 or 0.

Example 1:

Input: a = "11", b = "1"
Output: "100"
Example 2:

Input: a = "1010", b = "1011"
Output: "10101"
'''

class Solution:
    def add_binary_str(self, left, right, jump):
        sum = int(left) + int(right) + int(jump)
        if sum == 0:
            return '0', '0'
        elif sum == 1:
            return '1', '0'
        elif sum == 2:
            return '0', '1'
        elif sum == 3:
            return '1', '1'
        else:
            raise Exception("sum is wrong")
        
    def addBinary(self, a: str, b: str) -> str:
        alen = len(a)
        blen = len(b)

        longstr = ""
        shortstr = ""
        if alen >= blen:
            longstr = a[::-1]
            shortstr = b[::-1]
        else:
            longstr = b[::-1]
            shortstr = a[::-1]

        jump = 0
        max_len = len(longstr)
        combine = ""
        for i in range(0, max_len):
            longsub = longstr[i]
            shortsub = shortstr[i] if i < len(shortstr) else '0'
            result, jump = self.add_binary_str(longsub, shortsub, jump)
            combine += result
        if jump == '1':
            combine += jump
        return combine[::-1]

        
def main():
    a = "111"
    b = "10"
    ret = Solution().addBinary(a, b)
    print(ret)

if __name__ == '__main__':
    main()