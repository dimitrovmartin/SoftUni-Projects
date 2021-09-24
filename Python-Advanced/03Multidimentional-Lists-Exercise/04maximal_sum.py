rows, cols = [int(x) for x in input().split()]

matrix = []

maximal_sum = 0
max_row = -1
max_col = -1

for row in range(rows):
    matrix.append([int(x) for x in input().split()])

for row in range(rows - 2):
    for col in range(cols - 2):
        current_sum = matrix[row][col] + \
                      matrix[row][col + 1] +\
                      matrix[row][col + 2] +\
                      matrix[row + 1][col] +\
                      matrix[row + 1][col + 1] +\
                      matrix[row+ 1][col+2] + \
                      matrix[row + 2][col] + \
                      matrix[row + 2][col + 1] + \
                      matrix[row + 2][col + 2]

        if current_sum > maximal_sum:
            maximal_sum = current_sum
            max_row = row
            max_col = col

print(f"Sum = {maximal_sum}")

for row in range(max_row, max_row + 3):
    for col in range(max_col, max_col + 3):
        print(matrix[row][col], end=' ')
    print()
