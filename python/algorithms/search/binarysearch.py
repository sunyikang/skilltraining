def binary_search(items, target):
    lower = 0   # index from head
    upper = len(items) - 1

    while lower < upper:
        # middle
        middle = lower + (upper - lower) // 2

        # if middle item is target
        if items[middle] == target:
            return middle

        # else move lower or upper
        if items[middle] > target:
            upper = middle - 1
        else:
            lower = middle + 1

    return None


items = [1, 2, 3, 4, 5, 6, 7, 8, 10, 13, 20, 100]
index = binary_search(items, 20)
print(index)
