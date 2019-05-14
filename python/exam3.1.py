
def mystery(t, k):
    if k == len(t) - 1:
        return True
    if t[k] > t[k+1]:
        return False
    print k
    return mystery(t, k+1)

def isGrowing(t):
    return mystery(t, 0)

t = [1,3,4,8,12]
print isGrowing(t)
