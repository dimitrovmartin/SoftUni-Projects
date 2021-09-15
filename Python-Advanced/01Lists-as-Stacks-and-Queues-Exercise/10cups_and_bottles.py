from collections import deque

cups = deque([int(cup) for cup in input().split()])
bottles = [int(bottle) for bottle in input().split()]

total_wasted_water = 0

while cups and bottles:
    cup = cups[0]
    bottle = bottles.pop()
    cup -= bottle

    if cup > 0:
        while cup > 0 and bottles:
            bottle = bottles.pop()
            cup -= bottle

            if cup <= 0:
                cups.popleft()

    else:
        cups.popleft()

    total_wasted_water += abs(cup)

if bottles:
    print(f"Bottles: ", end='')
    print(*bottles)
else:
    print(f"Cups: ", end='')
    print(*cups)

print(f"Wasted litters of water: {total_wasted_water}")
