"""
Answer: 
    [describe the information that it provide]

    It looks for whether there is a K (element in table) that is 
    equal to (the length of table - 1), and the element cannot be 
    smaller than its next (right side) element.
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
