cells = input().split("#")
water = int(input())

cells_by_value = []

total_fire = 0
effort = 0

for cell in cells:
    cell_data = cell.split(" = ")
    type_of_fire = cell_data[0]
    range_of_fire = int(cell_data[1])

    if water - range_of_fire >= 0:
        if type_of_fire == "High" and 81 <= range_of_fire <= 125 or \
                type_of_fire == "Medium" and 51 <= range_of_fire <= 80 or \
                type_of_fire == "Low" and 1 <= range_of_fire <= 50:
            water -= range_of_fire
            total_fire += range_of_fire
            effort += range_of_fire * 0.25
            cells_by_value.append(range_of_fire)

print("Cells:")

for cell in cells_by_value:
    print(f" - {cell}")

print(f"Effort: {effort:.2f}")
print(f"Total Fire: {total_fire}")



