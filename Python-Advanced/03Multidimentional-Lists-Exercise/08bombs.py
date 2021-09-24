def is_valid(bomb_row, bomb_col, n, matrix):
    return 0 <= bomb_row < n and 0 <= bomb_col < n and matrix[bomb_row][bomb_col] > 0


n = int(input())

matrix = []
for row in range(n):
    matrix.append([int(x) for x in input().split()])

bombs = input().split()

for bomb in bombs:
    bomb_row, bomb_col = [int(x) for x in bomb.split(',')]

    if is_valid(bomb_row, bomb_col, n, matrix):
        if is_valid(bomb_row - 1, bomb_col - 1, n, matrix):
            matrix[bomb_row - 1][bomb_col - 1] -= matrix[bomb_row][bomb_col]
        if is_valid(bomb_row - 1, bomb_col, n, matrix):
            matrix[bomb_row - 1][bomb_col] -= matrix[bomb_row][bomb_col]
        if is_valid(bomb_row - 1, bomb_col + 1, n, matrix):
            matrix[bomb_row - 1][bomb_col + 1] -= matrix[bomb_row][bomb_col]
        if is_valid(bomb_row, bomb_col - 1, n, matrix):
            matrix[bomb_row][bomb_col - 1] -= matrix[bomb_row][bomb_col]
        if is_valid(bomb_row, bomb_col + 1, n, matrix):
            matrix[bomb_row][bomb_col + 1] -= matrix[bomb_row][bomb_col]
        if is_valid(bomb_row + 1, bomb_col - 1, n, matrix):
            matrix[bomb_row + 1][bomb_col - 1] -= matrix[bomb_row][bomb_col]
        if is_valid(bomb_row + 1, bomb_col, n, matrix):
            matrix[bomb_row + 1][bomb_col] -= matrix[bomb_row][bomb_col]
        if is_valid(bomb_row + 1, bomb_col + 1, n, matrix):
            matrix[bomb_row+1][bomb_col + 1] -= matrix[bomb_row][bomb_col]

        matrix[bomb_row][bomb_col] = 0


alive_cells = 0
sum = 0

for row in range(n):
    for col in range(n):
        if matrix[row][col] > 0:
            alive_cells += 1
            sum += matrix[row][col]

print(f'Alive cells: {alive_cells}')
print(f'Sum: {sum}')

for row in range(n):
    print(' '.join([str(x) for x in matrix[row]]))
