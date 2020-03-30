"""
Describe the function complexity in the best case and the worst case

Answer:   
Best case: log2(N)
Worse case: ?
"""


def syrac(n):
    while n > 1:
        if n % 2 == 0:
            n = n//2
        else:
            n = 3*n + 1
        print(n)
    return n


print(syrac(32))
print(syrac(20))
