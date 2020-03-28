/*
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

Solution:

    Build a binary tree. Each step there will be 2 choices until the end have 1 choice.
    To the end means found a solution, and shall add to a global count.
    There must be a number to record how many steps it left.
*/

#include <iostream>
using namespace std;

class Solution {
public:
    int climbStairs(int n) {
        int oneStepCount = climbNestStair(n, 1);
        int twoStepsCount = climbNestStair(n, 2);
        return oneStepCount + twoStepsCount;
    }

private:
    int climbNestStair(int leftStairs, int steps) {
        if (steps > leftStairs) {
            return 0;
        }

        // update status
        leftStairs -= steps;

        // check edge
        if (leftStairs == 0 || leftStairs == 1) {
            // reach end point since can only climb one step in next round
            return 1;
        }
        else if (leftStairs == 2) {
            // reach end point but has 2 possibility
            return 2;
        }
        else {
            // continue climb
            int oneStepCount = climbNestStair(leftStairs, 1);
            int twoStepsCount = climbNestStair(leftStairs, 2);
            return oneStepCount + twoStepsCount;
        }
    }
};

int test(Solution solution, int stairs) {
    int cases = solution.climbStairs(stairs);
    cout << "stairs: " << stairs << "\n";
    cout << "cases: " << cases << "\n";
    cout << "done! " << "\n";
}

int main() {
    auto solution = Solution();
    test(solution, 0);
    test(solution, 1);
    test(solution, 2);
    test(solution, 44);
}
