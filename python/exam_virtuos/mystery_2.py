"""
Answer: 
    The return is False!

    [describe all the recursive calls]
    
    1) k = 0, k == len(t) - 1 return False, t[0] > t[1] return False, go next
    2) k = 1, k == len(t) - 1 return False, t[1] > t[2] return True, mystery() return False
"""


def mystery(t, k):
    if k == len(t) - 1:
        return True
    if t[k] > t[k+1]:
        return False
    return mystery(t, k+1)


t = [6, 9, 4, 8, 12]
result = mystery(t, 0)
print(result)
