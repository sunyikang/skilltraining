# // class Meeting {
# //   double start;
# //   double end;
# // }
# //
# // Given person A and B’s schedule today, find their busy time.
# // Note: Busy time means A or B, or both are in a meeting.
# //            e.g. meetingA = [1,4], meetingB = [2,5] ==> BusyTime = [1,5]
# //
# // - For a given person, all meetings are not conflicting with each other
# // - All meetings are sorted by the start time.
# //
# // Example:
# // A = [[1, 2], [4, 6], [9, 12]]
# // B = [[0, 2], [5, 8]]
# // Busy = [[0,2], [4,8], [9,12]]

# // A = [[1, 2], [4, 6], [9, 12]]
# // B = [[0, 2], [5, 8]]
# // Busy = [[0,2], [4,8], [9,12]]

# [[0, 2], [1, 2], [4, 6], [5, 8], [9, 12]]

# A[pA] = [1, 2]
# B[pB] = [0, 2]

# merged = []

# v = [1, 2]
# merged = [0, 2]

# A[pA] = [4, 6]
# B[pB] = [5, 8]
# merged = [0, 2]

# A + merged == > [0, 2]

# result = [0, 2][4, 8][9, 12]

# 1. concate A / B and sort   O(n+m)
# 2. go through one by one, merge create new connect  O(n)

# pA, pB
# go through A, go through B


def cal_busy_for_2_person(A, B):

    def is_A_smaller(av, bv):
        return av[0] < bv[0]

    def process(v, merged, result):
        if not merged:
            merged = v
            return merged
        else:
            if v[0] <= merged[1]:
                # means can merge
                merged = [merged[0], v[1]]
                return merged
            else:
                # means shall split
                result.append(merged)
                merged = v
                return merged

    result = []
    pA = 0
    pB = 0

    merged = []
    while True:
        av = A[pA]
        bv = B[pB]

        if is_A_smaller(A[pA], B[pB]):
            merged = process(av, merged, result)
            pA += 1
            if pA == len(A):
                break
        else:
            merged = process(bv, merged, result)
            pB += 1
            if pB == len(B):
                break

    result.append(merged)

    # deal with the rest meeting
    while pA < len(A):
        result.append(A[pA])
        pA += 1

    while pB < len(B):
        result.append(B[pB])
        pB += 1

    return result


A = [[1, 2], [4, 6], [9, 12]]
B = [[0, 2], [5, 8]]

C = cal_busy_for_2_person(A, B)
print(C)
