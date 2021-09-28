def is_outside(row, col, n):
    return row < 0 or row >= n or col < 0 or col >= n


def get_next_position(direction, row, col):
    if direction == 'up':
        return row - 1, col
    if direction == 'down':
        return row + 1, col
    if direction == 'left':
        return row, col - 1
    return row, col + 1


n = int(input())

matrix = []

alice_row, alice_col = 0, 0

for row in range(n):
    elements = input().split()
    matrix.append(elements)

    for col in range(n):
        if matrix[row][col] == 'A':
            alice_row, alice_col = row, col

matrix[alice_row][alice_col] = '*'

collected_tea = 0

while True:
    direction = input()
    alice_row, alice_col = get_next_position(direction, alice_row, alice_col)

    if is_outside(alice_row, alice_col, n):
        break

    element = matrix[alice_row][alice_col]

    matrix[alice_row][alice_col] = '*'

    if element == 'R':
        break

    if element.isdigit():
        collected_tea += int(element)

        if collected_tea >= 10:
            break


if collected_tea >= 10:
    print('She did it! She went to the party.')
else:
    print("Alice didn't make it to the tea party.")

[print(' '.join(row)) for row in matrix]
