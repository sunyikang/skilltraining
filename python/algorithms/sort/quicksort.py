"""
Idea:   use head as pivot, put all smaller to left, all bigger to the right, 
        then conque left and right.
Different from mergesort: conque first then divide
Complexity:  O(nlog(n)) and usually better than merge sort.  
Worse case:  O(n^2) when it is reverse sorted before.

Ref Course: https://www.linkedin.com/learning/programming-foundations-algorithms/the-quicksort?autoplay=true
"""


def quicksort(items, first, last):
    if first < last:
        # conque
        pivot_id = partition(items, first, last)

        # divide
        quicksort(items, first, pivot_id - 1)
        quicksort(items, pivot_id + 1, last)


def partition(items, first, last):
    pivot = items[first]

    lower = first + 1   # index go on lower item
    upper = last        # index go on upper item

    while True:
        # advance the lower index, stop when encounter upper
        if items[lower] <= pivot:
            lower += 1

        # advance the upper index, stop when encounter lower
        if items[upper] > pivot:
            upper -= 1

        # check done
        if lower > upper:
            break

        # swap items on lower and upper
        x = items[lower]
        items[lower] = items[upper]
        items[upper] = x

    # move the items and insert the pivot to the middle
    x = pivot
    j = first            # index on items
    while j < upper:
        items[j] = items[j+1]
        j += 1
    items[upper] = pivot

    # return the pivot new id
    return upper


items = [3, 4, 5, 6, 3, 5, 7, 3, 5, 7, -2, 4, 0, 2]
print(items)
quicksort(items, 0, len(items) - 1)
print(items)
