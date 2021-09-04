wagons_count = int(input())

train = [0] * wagons_count

line = input()

while not line == "End":
    command_data = line.split()
    command = command_data[0]

    if command == "add":
        people = int(command_data[1])
        train[-1] += people
    elif command == "insert":
        index = int(command_data[1])
        people = int(command_data[2])

        if 0 <= index < wagons_count:
            train[index] += people
    elif command == "leave":
        index = int(command_data[1])
        people = int(command_data[2])

        if 0 <= index < wagons_count:
            train[index] -= people

    line = input()

print(train)