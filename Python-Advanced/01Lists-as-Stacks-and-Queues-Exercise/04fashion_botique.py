clothes = [int(cloth) for cloth in input().split()]
rack_capacity = int(input())

current_rack_capacity = rack_capacity
racks_count = 1

while clothes:
    cloth = clothes.pop()

    if current_rack_capacity < cloth:
        current_rack_capacity = rack_capacity
        racks_count += 1

    current_rack_capacity -= cloth

print(racks_count)