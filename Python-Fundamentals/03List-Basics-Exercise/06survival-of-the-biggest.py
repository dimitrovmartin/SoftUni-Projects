numbers = input().split()
n = int(input())

numbers = [int(x) for x in numbers]

for _ in range(n):
    min_number = min(numbers)

    numbers.remove(min_number)

numbers = [str(x) for x in numbers]

print(", ".join(numbers))