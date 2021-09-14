string = input()
stack = list(string)

reversed_string = []

while stack:
    reversed_string.append(stack.pop())

print("".join(reversed_string))

