
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
    def addBinary(self, a: str, b: str) -> str:
        sum = int(a, 2) + int(b, 2)
        answer = bin(sum)[2:]
        return answer

        
def main():
    a = "111"
    b = "10"
    ret = Solution().addBinary(a, b)
    print(ret)

if __name__ == '__main__':
    main()