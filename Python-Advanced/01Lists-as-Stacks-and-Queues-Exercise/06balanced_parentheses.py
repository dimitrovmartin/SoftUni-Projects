expression = input()

stack = []
is_balanced = True

for char in expression:
    if char in "{[(":
        stack.append(char)
    else:
        if stack:
            starting_bracket = stack.pop()
            closing_bracket = char

            pair = starting_bracket + closing_bracket

            if pair not in "{}[]()":
                is_balanced = False
                break
        else:
            is_balanced = False
            break

if is_balanced and not stack:
    print("YES")
else:
    print("NO")