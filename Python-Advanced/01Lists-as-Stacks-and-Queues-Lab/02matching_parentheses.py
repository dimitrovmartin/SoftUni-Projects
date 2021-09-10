problem = input()
stack = []

for i in range(len(problem)):
    current_symbol = problem[i]

    if current_symbol == "(":
        stack.append(i)
    elif current_symbol == ")":
        start_index = stack.pop()

        print(problem[start_index:i+1])
