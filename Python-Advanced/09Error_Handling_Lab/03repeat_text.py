text = input()

try:
    repeat_count = int(input())
except ValueError:
    print("Variable times must be an integer")
else:
    print(text * repeat_count)