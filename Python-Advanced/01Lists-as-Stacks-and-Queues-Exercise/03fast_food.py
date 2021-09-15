from collections import deque

food_quantity = int(input())
orders = input().split()

queue = deque([int(order) for order in orders])
biggest_order = max(queue)
is_food_enough = True

while queue:
    order = queue[0]

    if order <= food_quantity:
        food_quantity -= order
        queue.popleft()
    else:
        is_food_enough = False
        break

print(biggest_order)

if is_food_enough:
    print("Orders complete")
else:
    print(f"Orders left: ", end='')
    print(*queue)
