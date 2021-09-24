n = int(input())

matrix = []

for _ in range(n):
    row = [int(x) for x in input().split()]
    matrix.append(row)

first_diagonal_sum = 0
second_diagonal_sum = 0

for row in range(n):
    first_diagonal_sum += matrix[row][row]
    second_diagonal_sum += matrix[row][-1 - row]

difference = abs(first_diagonal_sum - second_diagonal_sum)

print(difference)