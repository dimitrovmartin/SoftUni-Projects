from collections import deque

pumps_count = int(input())
pumps = deque()

for _ in range(pumps_count):
    pump = [int(value) for value in input().split()]
    pumps.append(pump)

for i in range(pumps_count):
    total_petrol = 0
    is_enough_petrol = True

    for petrol, distance in pumps:
        total_petrol += petrol

        if total_petrol < distance:
            is_enough_petrol = False
            break
        else:
            total_petrol -= distance

    if is_enough_petrol:
        print(i)
        break
    else:
        current_pump = pumps.popleft()
        pumps.append(current_pump)

