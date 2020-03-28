# We consider the sequence defined as:
# {
# a) Write an iterative function that takes as parameter a natural integer n and computes
# the term un of the sequence by using a while loop.
# b) Write an iterative function that takes as parameter a natural integer n and computes
# the term un of the sequence by using a for loop.
# c) Write an recursive function that takes as parameter a natural integer n and computes
# the term un of the sequence.
# d) Write a function which, given an integer m, calculates the index of the first term of the
# sequence that is greater than or equal to m (example: if m = 30, the function will return
# 3 because all terms of index less than 3 are smaller than 30).

def CalculateFun(n):
    return 3 * n - 1

def CalculateDetail_ViaRecursive(result, n):

    if n > 1:
        newResult = CalculateFun(result)
        n -= 1
        return CalculateDetail_ViaRecursive(newResult, n)
    else:
        return result

def Calculate(n):
    if(n < 0):
        return 0
    elif (n == 0):
        return 2
    else:
        result = CalculateDetail_ViaRecursive(2, n)
        return result

print Calculate(0)
