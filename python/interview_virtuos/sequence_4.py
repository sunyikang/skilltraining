def compute(n):
    result = helper(n)
    return result


def helper(n):
    if n > 1:
        return 3 * helper(n-1) - 1
    if n == 1:
        return 3 * 2 - 1


result = compute(1)
print(result)
