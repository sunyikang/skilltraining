
def hasDuplicate(t):
    front = t[0]
    back = t[0]

    for i in range(0, len(t) - 1):
        front = t[i]
        for j in range(i + 1, len(t) - 1):
            back = t[j]
            if front == back:
                print front
                return True
    return False

table = [1, 2, 1]
print hasDuplicate(table)
