from collections import deque

water_quantity = int(input())
queue = deque()

name = input()

while not name == "Start":
    queue.append(name)
    name = input()

command = input()

while not command == "End":
    if "refill" in command:
        liters_to_refill = int(command.split()[1])

        water_quantity += liters_to_refill
    else:
        name = queue.popleft()
        liters = int(command)

        if water_quantity >= liters:
            water_quantity -= liters

            print(f"{name} got water")
        else:
            print(f"{name} must wait")

    command = input()

print(f"{water_quantity} liters left")




