n = int(input())
licence_plates = set()

for _ in range(n):
    command, licence_plate = input().split(", ")

    if command == "IN":
        licence_plates.add(licence_plate)
    elif command == "OUT":
        if licence_plate in licence_plates:
            licence_plates.remove(licence_plate)

if licence_plates:
    [print(licence_plate) for licence_plate in licence_plates]
else:
    print("Parking Lot is Empty")