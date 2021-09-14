expression = input()
stack = []

for index, value in enumerate(expression):
    if value == "(":
        stack.append(index)
    elif value == ")":
        start_index = stack.pop()
        end_index = index

        print(expression[start_index:end_index+1])

