def syrac(n):
    while n>1:
        if n%2 == 0:
            print "{} and {}".format("a1", n)
            n=n//2
            print "{} and {}".format("a2", n)
        else:
            print "{} and {}".format("b1", n)
            n=3*n +1
            print "{} and {}".format("b2", n)
    return n

print syrac(9)