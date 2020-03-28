
def internal(t):

    dict={}
    for i in range(0, len(t)):
        dict[i] = 0
    print dict

    for x in t:
        dict[x] = 1

    for x in dict:
        if dict[x] == 0:
            return False

    return True

table = [1, 0, 3]
print internal(table)

