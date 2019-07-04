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
        x = str(x)
        
        negative = False
        if x.startswith('-'):
            negative = True
            x = x[1::1]
        
        x = x[::-1]
        while x.startswith("0") and len(x) != 1:
            x = x[1::1]
            
        max = str(2**31 - 1)
        min = str(2**31)
        
        if (not negative):
            if (len(x) > len(max)) or ( len(x) == len(max) and x > max):
                print('out of max')
                print(x)
                print(str(min))
                x = 0
            
        if negative:
            if (len(x) > len(min)) or ( len(x) == len(min) and x > min):
                print('out of min')
                print(x)
                print(str(min))
                x = 0
            
        if negative:
            return -int(x)
        return int(x)


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