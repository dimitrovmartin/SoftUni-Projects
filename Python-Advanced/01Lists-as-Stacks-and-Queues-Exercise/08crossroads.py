from collections import deque

green_light_seconds = int(input())
yellow_light_seconds = int(input())

queue = deque()

hitted_car = ""
hitted_char = ""
is_crash_happened = False
total_cars_passed = 0

line = input()

while not line == "END":
    if line == "green":
        current_green_seconds = green_light_seconds

        while queue and current_green_seconds:
            total_cars_passed += 1

            car = queue.popleft()
            car_length = len(car)

            if current_green_seconds >= car_length:
                current_green_seconds -= car_length
            else:
                if current_green_seconds + yellow_light_seconds >= car_length:
                    current_green_seconds = 0
                    continue
                else:
                    hitted_car = car
                    hitted_char = car[current_green_seconds + yellow_light_seconds]
                    is_crash_happened = True
                    break

            if is_crash_happened:
                break

    else:
        queue.append(line)

    if is_crash_happened:
        break
    else:
        line = input()

if is_crash_happened:
    print("A crash happened!")
    print(f"{hitted_car} was hit at {hitted_char}.")
else:
    print("Everyone is safe.")
    print(f"{total_cars_passed} total cars passed the crossroads.")