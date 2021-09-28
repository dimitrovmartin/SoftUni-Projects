# 50/100

def is_outside(row, col, n):
    return row < 0 or row >= n or col < 0 or col >= n


def get_houses_in_range(size, row, col):
    houses = []

    if not is_outside(row - 1, col, size):
        houses.append([row - 1, col])
    if not is_outside(row + 1, col, size):
        houses.append([row + 1, col])
    if not is_outside(row, col - 1, size):
        houses.append([row, col - 1])
    if not is_outside(row, col + 1, size):
        houses.append([row, col + 1])

    return houses


def get_next_position(direction, row, col):
    if direction == 'up':
        return row - 1, col
    if direction == 'down':
        return row + 1, col
    if direction == 'left':
        return row, col - 1
    return row, col + 1


number_of_presents = int(input())
size = int(input())

matrix = []

santa_row, santa_col = 0, 0
initial_good_kids = 0

for row in range(size):
    elements = input().split()
    matrix.append(elements)

    for col in range(size):
        element = matrix[row][col]

        if element == 'S':
            santa_row, santa_col = row, col
        elif element == 'V':
            initial_good_kids += 1

good_kids = initial_good_kids

command = input()

while not command == 'Christmas morning':
    next_row, next_col = get_next_position(command, santa_row, santa_col)
    element = matrix[next_row][next_col]

    if element == 'V':
        matrix[santa_row][santa_col] = 'S'
        number_of_presents -= 1
        good_kids -= 1

    elif element == 'C':
        houses_in_range = get_houses_in_range(size, next_row, next_col)

        for row, col in houses_in_range:
            element = matrix[row][col]

            if element == 'V':
                number_of_presents -= 1
                good_kids -= 1
            elif element == 'X':
                number_of_presents -= 1

            matrix[row][col] = '-'

            if not number_of_presents:
                break

    matrix[santa_row][santa_col] = '-'
    matrix[next_row][next_col] = 'S'

    santa_row, santa_col = next_row, next_col

    if not number_of_presents:
        break

    command = input()

if not number_of_presents and good_kids:
    print('Santa ran out of presents!')

[print(' '.join(row)) for row in matrix]

if not good_kids:
    print(f'Good job, Santa! {initial_good_kids} happy nice kid/s.')
else:
    print(f'No presents for {good_kids} nice kid/s.')
