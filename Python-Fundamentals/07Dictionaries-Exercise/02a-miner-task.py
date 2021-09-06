resources_by_quantity = {}

line = input()

while not line == "stop":
    quantity = int(input())

    if line in resources_by_quantity:
        resources_by_quantity[line] += quantity
    else:
        resources_by_quantity[line] = quantity

    line = input()

for key, value in resources_by_quantity.items():
    print(f"{key} -> {value}")

