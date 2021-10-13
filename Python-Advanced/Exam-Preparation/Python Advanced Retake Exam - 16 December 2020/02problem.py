def are_coordinates_valid(next_row, next_col, n):
    return 0 <= next_row < n and 0 <= next_col < n


word = list(input())
n = int(input())

matrix = []

player_row, player_col = 0, 0

directions = {
    'up': lambda r, c: (r - 1, c),
    'down': lambda r, c: (r + 1, c),
    'left': lambda r, c: (r, c - 1),
    'right': lambda r, c: (r, c + 1)
}

for row in range(n):
    elements = list(input())
    matrix.append(elements)
    for col in range(n):
        if matrix[row][col] == 'P':
            player_row, player_col = row, col
            break

commands_count = int(input())

for _ in range(commands_count):
    command = input()

    next_row, next_col = directions[command](player_row, player_col)

    if are_coordinates_valid(next_row, next_col, n):
        element = matrix[next_row][next_col]
        matrix[player_row][player_col] = '-'

        player_row, player_col = next_row, next_col
        matrix[player_row][player_col] = 'P'

        if element == '-':
            continue

        word.append(element)
    else:
        if word:
            word.pop()

print(''.join(word))

for row in matrix:
    print(''.join(row))
