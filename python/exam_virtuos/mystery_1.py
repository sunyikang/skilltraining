"""
Answer: 
    The return is True!

    [describe all the recursive calls]
    
    1) k = 2, k == len(t) - 1 return False, t[2] > t[3] return False, go next
    2) k = 3, k == len(t) - 1 return False, t[3] > t[4] return False, go next
    3) k = 4, k == len(t) - 1 return True, mystery() return True
"""


def mystery(t, k):
    if k == len(t) - 1:
        return True
    if t[k] > t[k+1]:
        return False
    return mystery(t, k+1)


t = [6, 9, 4, 8, 12]
result = mystery(t, 2)
print(result)
