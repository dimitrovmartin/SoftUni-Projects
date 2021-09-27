lists = input().split('|')

matrix = []

for idx in range(len(lists) - 1 , -1, -1):
    matrix += lists[idx].split()

print(' '.join(matrix))