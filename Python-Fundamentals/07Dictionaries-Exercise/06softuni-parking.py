people_by_licence_plates = {}

n = int(input())

for _ in range(n):
    command_data = input().split()
    command = command_data[0]
    name = command_data[1]

    if command == "register":
        if name in people_by_licence_plates.keys():
            print(f"ERROR: already registered with plate number {people_by_licence_plates[name]}")
        else:
            licence_plate = command_data[2]

            people_by_licence_plates[name] = licence_plate

            print(f"{name} registered {licence_plate} successfully")
    elif command == "unregister":
        if name not in people_by_licence_plates.keys():
            print(f"ERROR: user {name} not found")
        else:
            people_by_licence_plates.pop(name)

            print(f"{name} unregistered successfully")

for key, value in people_by_licence_plates.items():
    print(f"{key} => {value}")
