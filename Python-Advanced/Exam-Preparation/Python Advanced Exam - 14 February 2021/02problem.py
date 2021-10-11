def are_valid_coordinates(row, col, n):
    return 0 <= row < n and 0 <= col < n


def is_wall(row, col, matrix):
    return matrix[row][col] == 'X'

n = int(input())

matrix = []

directions = {
    'up': lambda a, b: (a - 1, b),
    'down': lambda a, b: (a + 1, b),
    'left': lambda a, b: (a, b - 1),
    'right': lambda a, b: (a, b + 1)
}

player_row, player_col = -1, -1
player_coins = 0
player_path = []

for row in range(n):
    line = input().split()
    matrix.append(line)
    for col in range(n):
        if matrix[row][col] == 'P':
            player_row, player_col = row, col
            break





while True:
    command = input()

    next_row, next_col = directions[command](player_row, player_col)

    if are_valid_coordinates(next_row, next_col, n) and not is_wall(next_row, next_col, matrix):
        player_row, player_col = next_row, next_col

        if matrix[player_row][player_col].isnumeric():
            coins = int(matrix[player_row][player_col])

            player_coins += coins
            player_path.append([player_row, player_col])

            if player_coins >= 100:
                break
    else:
        player_coins //= 2
        break


if player_coins >= 100:
    print(f"You won! You've collected {player_coins} coins.")
else:
    print(f"Game over! You've collected {player_coins} coins.")

print(f'Your path:')
[print(row) for row in player_path]
