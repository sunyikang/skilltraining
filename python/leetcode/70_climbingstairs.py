"""
Requirement:

    https://leetcode.com/problems/climbing-stairs/

    You are climbing a stair case. It takes n steps to reach to the top.

    Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

    Note: Given n will be a positive integer.

    Example 1:

    Input: 2
    Output: 2
    Explanation: There are two ways to climb to the top.
    1. 1 step + 1 step
    2. 2 steps
    Example 2:

    Input: 3
    Output: 3
    Explanation: There are three ways to climb to the top.
    1. 1 step + 1 step + 1 step
    2. 1 step + 2 steps
    3. 2 steps + 1 step
"""

"""
Solution:

    Each time step 1 or 2, the left stairs' possible cases is fixed. 
    If maintain a dictionary to check the cases, then do not need to run into details anymore.
    It is a dynamical programming, from 1 start fill in the dictionary.

    Dictionary[stairs] = cases
"""


class Solution:
    def climbStairs(self, n: int) -> int:
        map = {}
        map[1] = 1
        map[2] = 2

        if n <= 2:
            return map[n]

        for stairs in range(3, n + 1):
            map[stairs] = map[stairs - 1] + map[stairs - 2]

        return map[n]


x = Solution().climbStairs(44)
print(x)
