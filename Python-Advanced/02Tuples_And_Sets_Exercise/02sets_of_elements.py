n, m = [int(number) for number in input().split()]

first_set = set()
second_set = set()

for _ in range(n):
    number = int(input())
    first_set.add(number)

for _ in range(m):
    number = int(input())
    second_set.add(number)

result = first_set.intersection(second_set)

[print(number) for number in result]
