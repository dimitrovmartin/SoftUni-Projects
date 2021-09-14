from collections import deque

children = input().split()
tosses = int(input())

hot_potato = deque(children)
counter = 0

while len(hot_potato) > 1:
    counter += 1
    child = hot_potato.popleft()

    if counter == tosses:
        print(f"Removed {child}")
        counter = 0
    else:
        hot_potato.append(child)

last_child = hot_potato.popleft()
print(f"Last is {last_child}")