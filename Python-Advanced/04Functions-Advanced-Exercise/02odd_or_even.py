command = input()
numbers = [int(x) for x in input().split()]

parity = 0 if command == 'Even' else 1
filtered_numbers = filter(lambda a: a % 2 == parity, numbers)

result = sum(filtered_numbers) * len(numbers)

print(result)
