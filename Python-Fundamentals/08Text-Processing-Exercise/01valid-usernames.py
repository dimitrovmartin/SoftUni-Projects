usernames = input().split(', ')
correct = []

for name in usernames:
    is_valid_username = True
    length = len(name)

    if 3 <= length < 16:
        for letter in name:
            if letter.isalpha():
                continue
            elif letter.isdigit():
                continue
            elif letter == "-":
                continue
            elif letter == "_":
                continue
            else:
                valid = False
                break
    else:
        continue
    if valid:
        correct.append(name)

print('\n'.join(correct))
