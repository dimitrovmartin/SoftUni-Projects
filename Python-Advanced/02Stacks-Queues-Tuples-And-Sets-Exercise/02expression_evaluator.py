from collections import deque

expression = input().split()
numbers = deque()

arithmetic_operations = {
    '+': lambda a, b: a + b,
    '-': lambda a, b: a - b,
    '*': lambda a, b: a * b,
    '/': lambda a, b: a // b
}

for char in expression:
    if char in arithmetic_operations.keys():
        while len(numbers) > 1:
            first_number = numbers.popleft()
            second_number = numbers.popleft()
            result = arithmetic_operations[char](first_number, second_number)

            numbers.appendleft(result)
    else:
        numbers.append(int(char))

print(numbers.popleft())