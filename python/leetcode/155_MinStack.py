"""
Requirement:
    https://leetcode.com/problems/min-stack/

    Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

    push(x) -- Push element x onto stack.
    pop() -- Removes the element on top of the stack.
    top() -- Get the top element.
    getMin() -- Retrieve the minimum element in the stack.
    

    Example:

    MinStack minStack = new MinStack();
    minStack.push(-2);
    minStack.push(0);
    minStack.push(-3);
    minStack.getMin();   --> Returns -3.
    minStack.pop();
    minStack.top();      --> Returns 0.
    minStack.getMin();   --> Returns -2.
"""

"""
Solution:

    2 stack. one for data, one for min data.
"""




import sys
class MinStack:

    def __init__(self):
        """
        initialize your data structure here.
        """
        self.stack = []
        self.min_stack = []

    def push(self, x: int) -> None:
        self.stack.append(x)
        min = x if x < self.min_stack[-1] else self.min_stack[-1]
        self.min_stack.append(min)

    def pop(self) -> None:
        length = len(self.stack)
        self.stack = self.stack[0: length - 1]
        self.min_stack = self.stack[0: length - 1]

    def top(self) -> int:
        length = len(self.stack)
        top = self.stack[length - 1]
        return top

    def getMin(self) -> int:
        return self.min_stack[-1]
