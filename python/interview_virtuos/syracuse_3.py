"""
Write the result for the two values: 32, 20. Please give all the successive values for n.

Answer:   
32 => 16 8 4 2 1 
20 => 10 5 1 
"""


def syrac(n):
    while n > 1:
        if n % 2 == 0:
            n = n//2
        else:
            n = 1
    return n


print(syrac(32))
print(syrac(20))
