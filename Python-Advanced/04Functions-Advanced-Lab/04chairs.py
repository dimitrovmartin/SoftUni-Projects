from itertools import combinations

names = input().split(', ')
n = int(input())

for combination in combinations(names, n):
    print(', '.join(combination))
