from collections import deque

bullet_price = int(input())
bullets_capacity = int(input())
bullets = [int(bullet) for bullet in input().split()]
locks = deque([int(lock) for lock in input().split()])
price = int(input())

shooted_bullets = 0
bullets_quantity = bullets_capacity

while bullets and locks:
    bullet = bullets.pop()
    lock = locks[0]

    bullets_quantity -= 1
    shooted_bullets += 1

    if bullet <= lock:
        locks.popleft()
        print("Bang!")
    else:
        print("Ping!")

    if not bullets_quantity:
        if bullets:
            print("Reloading!")
            bullets_quantity = bullets_capacity

if locks:
    print(f"Couldn't get through. Locks left: {len(locks)}")
else:
    money_earned = price - shooted_bullets * bullet_price

    print(f"{len(bullets)} bullets left. Earned ${money_earned}")
