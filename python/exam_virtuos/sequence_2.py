def compute(n):
    u = 2
    for count in range(0, n):
        u = 3 * u - 1
        count += 1
    return u


result = compute(1)
print(result)
