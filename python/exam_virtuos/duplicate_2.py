"""
Assumption:

    What does table means?  My assumption is a list of number.  Basing on that, I am coding.

"""


def internal(table):
    nummax = 0
    numset = set()

    for element in table:
        if element not in numset:
            numset.add(element)

        nummax = element if element > nummax else nummax

    for i in range(0, nummax+1):
        if i not in numset:
            return False

    return True


table0 = [1, 4, 3, 8, 16]
print(internal(table0))

table1 = [1, 0, 0]
print(internal(table1))

table2 = [1, 0, 2, 3]
print(internal(table2))
