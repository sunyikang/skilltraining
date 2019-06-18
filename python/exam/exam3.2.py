
def isInside(t,x,k):
    if k == len(t) - 1:
        return False
    if t[k] == x:
        return True
    return isInside(t, x, k+1)

t = [1,3,4,8,12]
print isInside(t, 3, 4)