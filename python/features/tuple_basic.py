#!/usr/bin/python

"""
https://www.tutorialspoint.com/python/python_tuples.htm
"""

# Accessing Values in Tuples
print('\naccess:')
tup1 = ('physics', 'chemistry', 1997, 2000)
tup2 = (1, 2, 3, 4, 5, 6, 7)
print("tup1[0]: ", tup1[0])
print("tup2[1:5]: ", tup2[1:5])


# Updating Tuples
print('\nupdate:')
tup1 = (12, 34.56)
tup2 = ('abc', 'xyz')
# Following action is not valid for tuples
# tup1[0] = 100;
# So let's create a new tuple as follows
tup3 = tup1 + tup2
print(tup3)

# Delete Tuple Elements
print('\ndelete:')
tup = ('physics', 'chemistry', 1997, 2000)
print(tup)
del tup
print("After deleting tup : ")
# print(tup)   NameError: name 'tup' is not defined

# Basic Tuples Operations
print('\nbasic:')
tuple1 = (1, 2, 3)
tuple2 = (4, 5, 6)
seq = [7, 8, 9]
print(tuple1 + tuple2)
print(tuple1 * 3)
print(3 in tuple1)
print(3 in tuple2)
print(tuple1[:2])
print(tuple1[1:])
print(tuple2[2])

# Built-in Tuple Functions
print('\nbuild-in:')
print(len(tuple1))
print(max(tuple1))
print(min(tuple1))
print(tuple(seq))
