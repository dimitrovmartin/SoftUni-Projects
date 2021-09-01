divisor = int(input())
bound = int(input())

largest_integer = 0
n = 0

while not n > bound:

    if n % divisor == 0:
        largest_integer = n

    n += 1

print(largest_integer)

