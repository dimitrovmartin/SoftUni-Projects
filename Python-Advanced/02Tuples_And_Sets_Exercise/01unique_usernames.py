n = int(input())

names = set()

for _ in range(n):
    name = input()
    names.add(name)

[print(name) for name in names]
