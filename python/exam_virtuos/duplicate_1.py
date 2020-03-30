"""
Assumption:

    What does table means?  My assumption is a list of number.  Basing on that, I am coding.

"""


def hasDuplicate(table):
    map = {}
    for element in table:
        if element in map:
            return True
        else:
            map[element] = 1

    return False


table0 = [1, 4, 3, 8, 16]
print(hasDuplicate(table0))

table1 = [1, 0, 0]
print(hasDuplicate(table1))

table2 = [1, 0, 2, 3]
print(hasDuplicate(table2))
