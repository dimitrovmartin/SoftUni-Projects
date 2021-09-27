def is_valid_index(row, col, matrix):
    rows = len(matrix)

    return 0 <= row < rows and 0 <= col < len(matrix[row])

n = int(input())

matrix = []

for _ in range(n):
    elements = [int(x) for x in input().split()]
    matrix.append(elements)

line = input()

while not line == 'END':
    command, row, col, value = line.split()
    row, col, value = int(row), int(col), int(value)

    if is_valid_index(row, col, matrix):
        if command == 'Add':
            matrix[row][col] += value
        elif command == 'Subtract':
            matrix[row][col] -= value
    else:
        print('Invalid coordinates')

    line = input()

for row in matrix:
    print(*row)

