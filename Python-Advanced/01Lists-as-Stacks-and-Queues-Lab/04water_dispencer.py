from collections import deque

water_quantity = int(input())
queue = deque()

name = input()

while not name == "Start":
    queue.append(name)
    name = input()

command = input()

while not command == "End":
    if command.startswith("refill"):
        liters_to_add = int(command.split()[1])
        water_quantity += liters_to_add
    else:
        liters_to_give = int(command)
        person = queue.popleft()

        if liters_to_give <= water_quantity:
            water_quantity -= liters_to_give
            print(f"{person} got water")
        else:
            print(f"{person} must wait")

    command = input()

print(f"{water_quantity} liters left")