def is_outside(row, col, n):
    return row < 0 or row >= n or col < 0 or col >= n


def get_next_position(direction, row, col, step=1):
    if direction == 'up':
        return row - step, col
    if direction == 'down':
        return row + step, col
    if direction == 'left':
        return row, col - step
    return row, col + step


n = 5
matrix = []

player_row, player_col = 0, 0
targets_count = 0
shot_targets = []

for row in range(n):
    elements = input().split()
    matrix.append(elements)

    for col in range(n):
        element = matrix[row][col]

        if element == 'A':
            player_row, player_col = row, col
        if element == 'x':
            targets_count += 1

commands_count = int(input())

for _ in range(commands_count):
    command_data = input().split()

    command = command_data[0]
    direction = command_data[1]

    if command == 'move':
        step = int(command_data[2])

        next_row, next_col = get_next_position(direction, player_row, player_col, step)

        if is_outside(next_row, next_col, n):
            continue

        element = matrix[next_row][next_col]

        if not element == '.':
            continue

        matrix[player_row][player_col] = '.'
        player_row, player_col = next_row, next_col
        matrix[player_row][player_col] = 'A'
    elif command == 'shoot':
        shoot_row, shoot_col = get_next_position(direction, player_row, player_col)

        while not is_outside(shoot_row, shoot_col, n):
            element = matrix[shoot_row][shoot_col]

            if element == 'x':
                matrix[shoot_row][shoot_col] = '.'
                targets_count -= 1
                shot_targets.append([shoot_row, shoot_col])
                break

            shoot_row, shoot_col = get_next_position(direction, shoot_row, shoot_col)

        if targets_count == 0:
            break

if targets_count == 0:
    print(f'Training completed! All {len(shot_targets)} targets hit.')
else:
    print(f'Training not completed! {targets_count} targets left.')

[print(target) for target in shot_targets]