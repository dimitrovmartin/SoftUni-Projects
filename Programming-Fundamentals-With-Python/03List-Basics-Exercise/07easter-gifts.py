gifts = input().split()

line = input()

while not line == "No Money":
    command_data = line.split()
    command = command_data[0]
    gift = command_data[1]

    if command == "OutOfStock":
        if gift in gifts:
            for i in range(len(gifts)):
                if gifts[i] == gift:
                    gifts[i] = None

    elif command == "Required":
        index = int(command_data[2])

        if 0 <= index < len(gifts):
            gifts[index] = gift
    elif command == "JustInCase":
        if gifts[-1] is not None:
            gifts[-1] = gift

    line = input()

gifts = list(filter(lambda x:  x is not None, gifts))

print(" ".join(gifts))
