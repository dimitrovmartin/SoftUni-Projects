n = int(input())

stack = []

for _ in range(n):
    command_data = input().split()
    command = command_data[0]

    if command == "1":
        element = command_data[1]
        stack.append(element)
    if command == "2":
        if stack:
            stack.pop()
    if command == "3":
        if stack:
            print(max(stack))
    if command == "4":
        if stack:
            print(min(stack))

print(", ".join(stack[::-1]))