n = int(input())

matrix = []
diagonal_sum = 0

for row in range(n):
    current_row = [int(el) for el in input().split()]
    matrix.append(current_row)

    diagonal_sum += matrix[row][row]

print(diagonal_sum)
