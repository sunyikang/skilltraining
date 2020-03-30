def compute(n):
    count = 0
    u = 2
    while count < n:
        u = 3 * u - 1
        count += 1
    return u


result = compute(1)
print(result)
