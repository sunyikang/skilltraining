"""
Packing vs. Unpacking

run python features/tuple_pack.py

https://www.geeksforgeeks.org/unpacking-a-tuple-in-python/
"""

# Program to understand about
# packing and unpacking in Python

# this lines PACKS values
# into variable a
a = ("MNNIT Allahabad", 5000, "Engineering")

# this lines UNPACKS values
# of variable a
(college, student, type_ofcollege) = a

# print college name
print(college)

# print no of student
print(student)

# print type of college
print(type_ofcollege)

# Python code to study about
# unpacking python tuple using *

# first and last will be assigned to x and z
# remaining will be assined to y
x, *y, z = (10, "Geeks ", " for ", "Geeks ", 50)

# print details
print(x)
print(y)
print(z)

# first and second will be assigned to x and y
# remaining will be assined to z
x, y, *z = (10, "Geeks ", " for ", "Geeks ", 50)
print(x)
print(y)
print(z)


# Python code to study about
# unpacking python tuple using function

# function takes normal arguments
# and multiply them
def result(x, y):
    return x * y


# function with normal variables
print(result(10, 100))

# A tuple is created
z = (10, 100)

# Tuple is passed
# function unpacked them

print(result(*z))

print(z)
print(*z)
