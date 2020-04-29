"""
What is the maximum number of recursive calls if the table size is n?

Answer: n
"""


def mystery(t, k):
    if k == len(t) - 1:
        return True
    if t[k] > t[k+1]:
        return False
    return mystery(t, k+1)


t = [0, 1, 2, 3, 4]
result = mystery(t, 0)
print(result)
