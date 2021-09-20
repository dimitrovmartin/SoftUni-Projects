rows, cols = [int(el) for el in input().split(", ")]

matrix = []
matrix_sum = 0

for row in range(rows):
    current_row = [int(el) for el in input().split(", ")]

    matrix.append(current_row)
    matrix_sum += sum(matrix[row])

print(matrix_sum)
print(matrix)