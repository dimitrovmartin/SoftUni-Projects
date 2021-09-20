rows, cols = [int(el) for el in input().split(", ")]

matrix = []
max_square_sum = 0
max_row = -1
max_col = -1

for row in range(rows):
    current_row = [int(el) for el in input().split(", ")]
    matrix.append(current_row)

for row in range(rows - 1):
    for col in range(cols - 1):
        square_sum = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1]

        if square_sum > max_square_sum:
            max_square_sum = square_sum
            max_row = row
            max_col = col

for row in range(max_row, max_row + 2):
    for col in range(max_col, max_col + 2):
        print(f"{matrix[row][col]} ", end="")
    print()

print(max_square_sum)