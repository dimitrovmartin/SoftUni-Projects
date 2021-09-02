n = int(input())

numbers = []

for _ in range(n):
    number = int(input())

    numbers.append(number)

command = input()

if command == "even":
    numbers = filter(lambda x: x % 2 == 0, numbers)
if command == "odd":
    numbers = filter(lambda x: not x % 2 == 0, numbers)
if command == "negative":
    numbers = filter(lambda x: x < 0, numbers)
if command == "positive":
    numbers = filter(lambda x: x >= 0, numbers)

print(list(numbers))
