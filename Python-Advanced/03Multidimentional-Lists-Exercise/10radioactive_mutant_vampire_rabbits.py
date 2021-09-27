def get_next_position(row, col, direction):
    if direction == 'L':
        return row, col - 1
    elif direction == 'R':
        return row, col + 1
    elif direction == 'U':
        return row - 1, col
    elif direction == 'D':
        return row + 1, col


def is_valid_position(row, col, n, m):
    return 0 <= row < n and 0 <= col < m


def get_bunnies_coordinates(matrix):
    bunnies_coordinates = []

    for row in range(len(matrix)):
        for col in range(len(matrix[row])):
            if matrix[row][col] == 'B':
                bunnies_coordinates.append((row, col))

    return bunnies_coordinates


def spread_bunnies(bunnies_coordinates, matrix):
    for bunny_row, bunny_col in bunnies_coordinates:
        if is_valid_position(bunny_row - 1, bunny_col, len(matrix), len(matrix[row])):
            matrix[bunny_row - 1][bunny_col] = 'B'
        if is_valid_position(bunny_row + 1, bunny_col, len(matrix), len(matrix[row])):
            matrix[bunny_row + 1][bunny_col] = 'B'
        if is_valid_position(bunny_row, bunny_col - 1, len(matrix), len(matrix[row])):
            matrix[bunny_row][bunny_col - 1] = 'B'
        if is_valid_position(bunny_row, bunny_col + 1, len(matrix), len(matrix[row])):
            matrix[bunny_row][bunny_col + 1] = 'B'


n, m = [int(x) for x in input().split()]

matrix = []
is_dead = False
is_outside = False

player_row, player_col = -1, -1

for row in range(n):
    row_elements = list(input())
    matrix.append(row_elements)

for row in range(n):
    for col in range(m):
        if matrix[row][col] == 'P':
            player_row, player_col = row, col
            break

directions = input()

for direction in directions:
    next_row, next_col = get_next_position(player_row, player_col, direction)

    if is_valid_position(next_row, next_col, n, m):
        matrix[player_row][player_col] = '.'
        player_row, player_col = next_row, next_col

        if matrix[next_row][next_col] == 'B':
            is_dead = True
    else:
        is_outside = True
        matrix[player_row][player_col] = '.'

    bunnies_coordinates = get_bunnies_coordinates(matrix)
    spread_bunnies(bunnies_coordinates, matrix)

    if is_dead or is_outside:
        break

    if matrix[player_row][player_col] == 'B':
        is_dead = True
        break


for row in matrix:
    print("".join(row))

if is_dead:
    print(f'dead: {player_row} {player_col}')
else:
    print(f'won: {player_row} {player_col}')
