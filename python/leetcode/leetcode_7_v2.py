'''
7. Reverse Integer

https://leetcode.com/problems/reverse-integer/

Given a 32-bit signed integer, reverse digits of an integer.

Example 1:

Input: 123
Output: 321
Example 2:

Input: -123
Output: -321
Example 3:

Input: 120
Output: 21
Note:
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
'''

class Solution:
    def reverse(self, x: int) -> int:
        
        INT_MAX_D10 = (2 ** 31 - 1) / 10
        INT_MIN_D10 = (2 ** 31)/10
        rev = 0
        temp = 0

        negative = -1 if x < 0 else 1
        x = abs(x)

        while x > 0:
            # pop
            pop = int(x % 10)
            x = int(x / 10)

            # check
            if negative == 1 and (rev > INT_MAX_D10 or (rev == INT_MAX_D10 and pop > 7)):
                return 0
            if negative == -1 and (rev > INT_MIN_D10 or (rev == INT_MIN_D10 and pop > 8)):
                return 0

            # push
            temp = rev * 10 + pop
            rev = temp
    
        return int(temp) * negative


def main():
    import sys
    import io
    def readlines():
        for line in io.TextIOWrapper(sys.stdin.buffer, encoding='utf-8'):
            yield line.strip('\n')

    lines = readlines()
    while True:
        try:
            line = next(lines)
            x = int(line);
            
            ret = Solution().reverse(x)

            out = str(ret);
            print(out)
        except StopIteration:
            break

if __name__ == '__main__':
    main()