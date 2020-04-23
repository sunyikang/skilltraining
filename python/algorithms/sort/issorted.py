def issorted(items):
    return all([items[i] < items[i+1] for i in range(len(items) - 1)])


items1 = [1, 2, 3, 4, 5, 6, 7, 8, 10, 13, 20, 100]
items2 = [1, 2, 90, 4, 5, 6, 7, 8, 10, 13, 20, 100]

print(issorted(items1))
print(issorted(items2))
