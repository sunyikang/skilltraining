"""
Describe the function complexity in the best case and the worst case

Answer:   
Best case: O(1)  e.g. 15   15 => 1
Worse case: log2(N)   e.g. 32.   32 => 16 8 4 2 1 
"""


def syrac(n):
    while n > 1:
        if n % 2 == 0:
            n = n//2
        else:
            n = 1
    return n


print(syrac(32))
print(syrac(15))
