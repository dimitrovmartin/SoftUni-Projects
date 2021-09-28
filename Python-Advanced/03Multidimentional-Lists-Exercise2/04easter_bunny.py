# 87/100

def is_valid_position(row, col, n):
    return 0 <= row < n and 0 <= col < n


n = int(input())

matrix = []

directions = {
    'left': lambda r, c: (r, c - 1),
    'right': lambda r, c: (r, c + 1),
    'up': lambda r, c: (r - 1, c),
    'down': lambda r, c: (r + 1, c)
}

bunny_row, bunny_col = 0, 0
best_direction = ''
best_path = []
max_eggs = float('-inf')

for row in range(n):
    elements = input().split()
    matrix.append(elements)

    for col in range(n):
        if matrix[row][col] == 'B':
            bunny_row, bunny_col = row, col


for direction, func in directions.items():
    collected_eggs = 0
    current_path = []
    next_row, next_col = bunny_row, bunny_col

    while True:
        next_row, next_col = func(next_row, next_col)

        if not is_valid_position(next_row, next_col, n):
            break

        if matrix[next_row][next_col] == 'X':
            break

        collected_eggs += int(matrix[next_row][next_col])
        current_path.append([next_row, next_col])

    if collected_eggs > max_eggs:
        max_eggs = collected_eggs
        best_path = current_path
        best_direction = direction

print(best_direction)

for step in best_path:
    print(step)

print(max_eggs)
