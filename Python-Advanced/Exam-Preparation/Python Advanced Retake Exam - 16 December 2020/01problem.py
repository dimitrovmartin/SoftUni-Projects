from collections import deque

males = [int(x) for x in input().split()]
females = deque([int(x) for x in input().split()])

matches = 0

while males and females:
    male = males.pop()
    female = females.popleft()

    if male <= 0:
        females.appendleft(female)
        continue
    if female <= 0:
        males.append(male)
        continue

    if male % 25 == 0:
        if males:
            males.pop()
        females.appendleft(female)
        continue
    if female % 25 == 0:
        if females:
            females.popleft()
        males.append(male)
        continue

    if male == female:
        matches += 1
    else:
        male -= 2
        males.append(male)

print(f'Matches: {matches}')

males = ', '.join(reversed(list(str(male) for male in males))) if males else 'none'
females = ', '.join([str(female) for female in females]) if females else 'none'

print(f'Males left: {males}')
print(f'Females left: {females}')
