n = int(input())

matrix = []

for _ in range(n):
    row = [int(x) for x in input().split(', ')]
    matrix.append(row)

first_diagonal = []
second_diagonal = []

for row in range(n):
    first_diagonal.append(matrix[row][row])
    second_diagonal.append(matrix[row][-1 - row])

print(f'Primary diagonal: {", ".join([str(x) for x in first_diagonal])}. Sum: {sum(first_diagonal)}')
print(f'Secondary diagonal: {", ".join([str(x) for x in second_diagonal])}. Sum: {sum(second_diagonal)}')