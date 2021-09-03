def calculate(command, a, b):
    if command == "multiply":
        return a * b
    elif command == "divide":
        return a // b
    elif command == "add":
        return a + b
    elif command == "subtract":
        return a - b


operator = input()
first_number = int(input())
second_number = int(input())

result = calculate(operator, first_number, second_number)

print(result)
