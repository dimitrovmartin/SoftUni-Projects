from collections import deque

queue = deque()
name = input()

while not name == "End":
    if name == "Paid":
        while queue:
            customer = queue.popleft()
            print(customer)
    else:
        queue.append(name)

    name = input()

print(f"{len(queue)} people remaining.")
