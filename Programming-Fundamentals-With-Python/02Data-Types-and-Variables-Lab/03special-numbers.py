n = int(input())


for number in range(1, n + 1):
    sum = 0
    current_number = number

    while current_number > 0:
        sum += current_number % 10

        current_number //= 10

    print(f"{number} -> ", end = '')

    if sum == 5 or sum == 7 or sum == 11:
        print(True)
    else:
        print(False)
