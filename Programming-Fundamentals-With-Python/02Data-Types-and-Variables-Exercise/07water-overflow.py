n = int(input())

max_capacity = 255
capacity = 0

for i in range(n):
    number = int(input())

    if capacity + number > max_capacity:
        print("Insufficient capacity!")
    else:
        capacity += number

print(capacity)
