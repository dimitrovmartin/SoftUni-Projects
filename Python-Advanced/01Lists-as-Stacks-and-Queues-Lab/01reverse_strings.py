stack = list(input())
reversed_string = []

while len(stack) > 0:
    reversed_string.append(stack.pop())

print("".join(reversed_string))