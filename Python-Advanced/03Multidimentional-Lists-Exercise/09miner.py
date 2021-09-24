def is_valid(row, col, n):
    return 0 <= row < n and 0 <= col < n


n = int(input())

matrix = []
miner_row = -1
miner_col = -1
coals = 0

game_over = False

directions = input().split()

for _ in range(n):
    matrix.append(input().split())

for row in range(n):
    for col in range(n):
        if matrix[row][col] == 's':
            miner_row = row
            miner_col = col
        if matrix[row][col] == 'c':
            coals += 1

for direction in directions:
    commands = {
        'up': (miner_row - 1, miner_col),
        'down': (miner_row + 1, miner_col),
        'left': (miner_row, miner_col - 1),
        'right': (miner_row, miner_col + 1)
    }

    next_row, next_col = commands[direction]

    if is_valid(next_row, next_col, n):
        matrix[miner_row][miner_col] = '*'

        miner_row, miner_col = next_row, next_col

        if matrix[next_row][next_col] == 'c':
            coals -= 1
            if not coals:
                break
        elif matrix[next_row][next_col] == 'e':
            game_over = True
            break

if game_over:
    print(f'Game over! ({miner_row}, {miner_col})')
elif not coals:
    print(f'You collected all coal! ({miner_row}, {miner_col})')
else:
    print(f"{coals} pieces of coal left. ({miner_row}, {miner_col})")