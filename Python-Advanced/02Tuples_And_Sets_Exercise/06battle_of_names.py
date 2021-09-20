n = int(input())

odd_set = set()
even_set = set()

for i in range(1, n + 1):
    name = input()
    name_sum = 0

    for char in name:
        name_sum += ord(char)

    name_sum //= i

    if name_sum % 2 == 0:
        even_set.add(name_sum)
    else:
        odd_set.add(name_sum)

even_set_sum = sum(even_set)
odd_set_sum = sum(odd_set)

result = set()

if odd_set_sum == even_set_sum:
    result = odd_set.union(even_set)
elif odd_set_sum > even_set_sum:
    result = odd_set.difference(even_set)
elif odd_set_sum < even_set_sum:
    result = odd_set.symmetric_difference(even_set)

print(*result, sep=', ')

