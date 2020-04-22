def findmax(items):
    # break condition
    if len(items) == 1:
        return items[0]

    # recursive
    op1 = items[0]
    op2 = findmax(items[1:])

    # real work
    if op1 < op2:
        return op2
    else:
        return op1


items = [3, 5, 2, 1]
print(findmax(items))
