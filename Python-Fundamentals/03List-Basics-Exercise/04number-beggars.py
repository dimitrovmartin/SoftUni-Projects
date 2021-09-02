numbers = input().split(", ")
beggars_count = int(input())

beggars_values = []

for beggar in range(beggars_count):
    sum = 0
    for i in range(beggar, len(numbers), beggars_count):
        sum += int(numbers[i])

    beggars_values.append(sum)

print(beggars_values)
