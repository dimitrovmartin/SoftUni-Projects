first_string, second_string = input().split()

result = 0


for i in range(max(len(first_string), len(second_string))):
    if len(first_string) > i:
        if len(second_string) > i:
            result += ord(first_string[i]) * ord(second_string[i])
        else:
            result += ord(first_string[i])
    elif len(second_string) > i:
        result += ord(second_string[i])

print(result)
