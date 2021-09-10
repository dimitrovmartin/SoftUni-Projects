numbers = tuple(input().split())
count_by_numbers = {}

for number in numbers:
    if number not in count_by_numbers.keys():
        count_by_numbers[number] = 0

    count_by_numbers[number] += 1

[print(f"{float(key)} - {value} times") for key, value in count_by_numbers.items()]
