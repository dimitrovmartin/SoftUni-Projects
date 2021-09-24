def is_valid_coordinate(rows, cols, row, col):
    return 0 <= row < rows and 0 <= col < cols


rows, cols = [int(x) for x in input().split()]

matrix = []

for row in range(rows):
    matrix.append([int(x) for x in input().split()])

line = input()

while not line == 'END':
    command, *indexes = line.split()

    if command == 'swap' and len(indexes) == 4:
        first_row, first_col, second_row, second_col = [int(x) for x in indexes]

        if is_valid_coordinate(rows, cols, first_row, first_col) and \
                is_valid_coordinate(rows, cols, second_row, second_col):
            matrix[first_row][first_col], matrix[second_row][second_col] = \
                matrix[second_row][second_col], matrix[first_row][first_col]

            for row in range(rows):
                print(' '.join([str(x) for x in matrix[row]]))
        else:
            print('Invalid input!')
    else:
        print('Invalid input!')

    line = input()
