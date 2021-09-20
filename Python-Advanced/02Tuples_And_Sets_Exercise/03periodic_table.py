n = int(input())

periodic_table = set()

for _ in range(n):
    elements = set(input().split())

    periodic_table = periodic_table.union(elements)

[print(element) for element in periodic_table]