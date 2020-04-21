def mergesort(items):
    if len(items) > 1:
        # devide
        length = len(items)
        middle = length // 2
        left = items[0:middle]
        right = items[middle:]
        left = mergesort(left)
        right = mergesort(right)

        # conque (do real merge for left and right)
        i = 0  # left index
        j = 0  # right index
        k = 0  # items index
        while i < len(left) and j < len(right):
            if left[i] < right[j]:
                items[k] = left[i]
                i += 1
            else:
                items[k] = right[j]
                j += 1
            k += 1

        # exceptions
        if i < len(left):
            while i < len(left):
                items[k] = left[i]
                k += 1
                i += 1
        if j < len(right):
            while j < len(right):
                items[k] = right[j]
                k += 1
                j += 1

    return items


items = [3, 4, 5, 6, 3, 5, 7, 3, 5, 7, -2, 4, 0, 2]
print(items)
mergesort(items)
print(items)
