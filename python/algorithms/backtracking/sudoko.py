"""
3 Keys of Backtracking Algorithm:

    - Choice
    - Constraints
    - Goal

REF:
https://www.youtube.com/watch?v=Zq4upTEaQyM
https://www.youtube.com/watch?v=JzONv5kaPJM

LEETCODE:
https://leetcode.com/problems/sudoku-solver/
"""


class Solution:
    def solveSudoku(self, board) -> None:
        """
        Do not return anything, modify board in-place instead.
        """
        def isCellHavingValue(row, col, board):
            return board[row][col] != '.'

        def findRangeList(num):
            three_list = [[0, 1, 2], [3, 4, 5], [6, 7, 8]]
            for one_list in three_list:
                if num in one_list:
                    return one_list

        def isValueValidInCell(row, col, board):
            # CONSTRAINTS
            # cannot break row board[row][i]
            # cannot break col board[j][col]
            # cannot break sub-box
            # row e.g.= 5, ==> findRange ==> list [3,4,5]
            current_value = board[row][col]

            for i in list(range(0, 9)):
                if i != col and board[row][i] == current_value:
                    return False

            for j in list(range(0, 9)):
                if j != row and board[j][col] == current_value:
                    return False

            row_list = findRangeList(row)
            col_list = findRangeList(col)
            for r in row_list:
                for c in col_list:
                    if r != row and c != col and board[r][c] == current_value:
                        return False

            return True

        def get_next_row_col(row, col, board):
            # GOAL
            # if row == 8 and col == 9 return done
            # if col == 9, then next_row = row+1 and next_col = 0
            # else next_row = row, next_col = col + 1
            # if board[next_row, next_col] has value, go next
            next_row = 0
            next_col = 0
            if col == 8:
                next_row = row + 1
                next_col = 0
            else:
                next_row = row
                next_col = col + 1

            if next_row == 9:
                print('GOAL')
                return 0, 0, True
            else:
                # print(next_row,'_',next_col)
                if isCellHavingValue(next_row, next_col, board):
                    return get_next_row_col(next_row, next_col, board)
                else:
                    return next_row, next_col, False

        def solve(row, col, board):
            # CHOICE:
            # in decision space [1, 9] choose one number and put in
            # the cell. Check whether it break the board. If not,
            # go to solve next cell.
            for value in list(range(1, 10)):
                board[row][col] = str(value)

                valid = isValueValidInCell(row, col, board)
                if valid:
                    # if (row == 8 and col == 6) or\
                    #     (row in [3, 4, 5, 7] and col == 7) or\
                    #         (row == 6 and col == 8):
                    if row == 0:
                        print('[', row, ']_[', col, '] = ', board[row], valid)
                    next_row, next_col, done = get_next_row_col(row, col, board)
                    if done:
                        return True
                    if solve(next_row, next_col, board):
                        return True

            board[row][col] = '.'
            return False

        init_row, init_col, _ = get_next_row_col(0, 0, board)
        solve(init_row, init_col, board)


"""
["5","3",".",".","7",".",".",".","."],
["6",".",".","1","9","5",".",".","."],
[".","9","8",".",".",".",".","6","."],
["8",".",".",".","6",".",".",".","3"],
["4",".",".","8",".","3",".",".","1"],
["7",".",".",".","2",".",".",".","6"],
[".","6",".",".",".",".","2","8","."],
[".",".",".","4","1","9",".",".","5"],
[".",".",".",".","8",".",".","7","9"]
"""
board = [["5", "3", ".", ".", "7", ".", ".", ".", "."], ["6", ".", ".", "1", "9", "5", ".", ".", "."], [".", "9", "8", ".", ".", ".", ".", "6", "."], ["8", ".", ".", ".", "6", ".", ".", ".", "3"], ["4", ".", ".", "8",
                                                                                                                                                                                                      ".", "3", ".", ".", "1"], ["7", ".", ".", ".", "2", ".", ".", ".", "6"], [".", "6", ".", ".", ".", ".", "2", "8", "."], [".", ".", ".", "4", "1", "9", ".", ".", "5"], [".", ".", ".", ".", "8", ".", ".", "7", "9"]]
Solution().solveSudoku(board)
print(board)
