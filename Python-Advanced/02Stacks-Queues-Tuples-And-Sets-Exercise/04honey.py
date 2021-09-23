from collections import deque

bees = deque([int(x) for x in input().split()])
nectar = [int(x) for x in input().split()]
signs = deque(input().split())

total_honey_made = 0

arithmetic_operations = {
    '+': lambda a, b: abs(a + b),
    '-': lambda a, b: abs(a - b),
    '*': lambda a, b: abs(a * b),
    '/': lambda a, b: abs(a / b)
}

while bees and nectar:
    bee = bees.popleft()
    current_nectar = nectar.pop()

    if bee <= current_nectar:
        sign = signs.popleft()
        if sign == '+':
            total_honey_made += abs(bee + current_nectar)
        elif sign == '-':
            total_honey_made += abs(bee - current_nectar)
        elif sign == '*':
            total_honey_made += abs(bee * current_nectar)
        elif sign == '/':
            if current_nectar > 0:
                total_honey_made += abs(bee / current_nectar)
    else:
        bees.appendleft(bee)


print(f'Total honey made: {total_honey_made}')

if bees:
    print(f"Bees left: {', '.join([str(x) for x in bees])}")

if nectar:
    print(f"Nectar left: {', '.join([str(x) for x in nectar])}")
