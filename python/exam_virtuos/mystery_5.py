"""
Write a function isGrowing(t) using the function mystery
"""


def isGrowing(t):
    return mystery(t, 0)


def mystery(t, k):
    if k == len(t) - 1:
        return True
    if t[k] > t[k+1]:
        return False
    return mystery(t, k+1)


t = [0, 1, 2, 5, 4]
result = isGrowing(t)
print(result)
