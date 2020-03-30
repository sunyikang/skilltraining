"""
Describe the function complexity in the best case and the worst case

Answer:   
Best case: log2(N)
Worse case: log2(N)
"""


def syr(n):
    while n > 1:
        n = n//2
    return n


print(syr(27))
print(syr(32))
