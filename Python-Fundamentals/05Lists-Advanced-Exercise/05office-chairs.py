n = int(input())

free_chairs = 0
is_chairs_enough = True

for i in range(n):
    data = input().split()

    chairs = len(data[0])
    visitors = int(data[1])
    needed_chairs = visitors - chairs

    if needed_chairs > 0:
        print(f"{needed_chairs} more chairs needed in room {i + 1}")

        is_chairs_enough = False
    else:
        free_chairs += abs(needed_chairs)


if is_chairs_enough:
    print(f"Game On, {free_chairs} free chairs left")
