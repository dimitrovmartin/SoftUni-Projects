from collections import deque

materials = [int(x) for x in input().split()]
magic = deque([int(x) for x in input().split()])

presents_by_value = {
    150: 'Doll',
    250: 'Wooden train',
    300: 'Teddy bear',
    400: 'Bicycle'
}

crafted_presents = {
    'Doll': 0,
    'Wooden train': 0,
    'Teddy bear': 0,
    'Bicycle': 0
}

while materials and magic:
    product = materials.pop()
    current_magic = magic.popleft()
    result = 0

    if product == 0 and current_magic == 0:
        continue
    elif product == 0:
        magic.appendleft(current_magic)
        continue
    elif current_magic == 0:
        materials.append(product)
        continue

    if product < 0 or current_magic < 0:
        result = product + current_magic
        materials.append(result)
        continue
    else:
        result = product * current_magic

    if result in presents_by_value.keys():
        present = presents_by_value[result]
        crafted_presents[present] += 1
    elif result > 0:
        product += 15
        materials.append(product)


is_done = (crafted_presents['Doll'] and crafted_presents['Wooden train']) or \
          (crafted_presents['Teddy bear'] and crafted_presents['Bicycle'])

if is_done:
    print("The presents are crafted! Merry Christmas!")
else:
    print("No presents this Christmas!")

if materials:
    print(f"Materials left: {', '.join(reversed([str(x) for x in materials]))}")

if magic:
    print(f"Magic left: {', '.join([str(x) for x in magic])}")

crafted_presents = sorted(crafted_presents.items())

for key, value in crafted_presents:
    if value:
        print(f'{key}: {value}')