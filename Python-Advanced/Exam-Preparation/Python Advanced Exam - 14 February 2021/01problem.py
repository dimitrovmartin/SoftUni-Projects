from collections import deque

fireworks = deque([int(x) for x in input().split(', ')])
explosives = [int(x) for x in input().split(', ')]

palm = 0
willow = 0
crossette = 0

are_fireworks_ready = False

while fireworks and explosives:
    firework = fireworks.popleft()
    explosive = explosives.pop()

    if firework <= 0:
        explosives.append(explosive)
        continue
    if explosive <= 0:
        fireworks.appendleft(firework)
        continue

    total = firework + explosive
    if total % 5 == 0 and not total % 3 == 0:
        willow += 1
    elif total % 3 == 0 and not total % 5 == 0:
        palm += 1
    elif total % 3 == 0 and total % 5 == 0:
        crossette += 1
    else:
        firework -= 1

        fireworks.append(firework)
        explosives.append(explosive)

    if palm >= 3 and willow >= 3 and crossette >= 3:
        are_fireworks_ready = True
        break


if are_fireworks_ready:
    print("Congrats! You made the perfect firework show!")
else:
    print("Sorry. You can't make the perfect firework show.")

if fireworks:
    print(f'Firework Effects left: {", ".join([str(firework) for firework in fireworks])}')
if explosives:
    print(f'Explosive Power left: {", ".join([str(explosive) for explosive in explosives])}')

print(f'Palm Fireworks: {palm}')
print(f'Willow Fireworks: {willow}')
print(f'Crossette Fireworks: {crossette}')