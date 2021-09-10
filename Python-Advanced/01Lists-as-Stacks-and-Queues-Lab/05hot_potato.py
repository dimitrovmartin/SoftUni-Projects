from collections import deque
queue = deque(input().split())
allowed_tosses = int(input())
current_tosses = 0

while len(queue) > 1:
    current_tosses += 1
    child = queue.popleft()

    if current_tosses == allowed_tosses:
        print(f"Removed {child}")
        
        current_tosses = 0
    else:
        queue.append(child)

print(f"Last is {queue.popleft()}")