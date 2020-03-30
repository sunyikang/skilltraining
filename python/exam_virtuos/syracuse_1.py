"""
Write the result for the two values: 32, 20. Please give all the successive values for n

Answer:   
32 => 16 8 4 2 1 
20 => 10 5 2 1 
"""


def syr(n):
    while n > 1:
        n = n//2
        print(n)
    return n


print(syr(32))
print(syr(20))
