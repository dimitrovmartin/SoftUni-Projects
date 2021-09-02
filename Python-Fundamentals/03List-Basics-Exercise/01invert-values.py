numbers_as_string = input().split()

inverted_numbers = []

for number in numbers_as_string:
    inverted_number = int(number) * -1

    inverted_numbers.append(inverted_number)

print(inverted_numbers)
