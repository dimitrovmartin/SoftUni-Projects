with open('numbers.txt', 'r') as file:
    numbers = [int(x) for x in file.read().split('\n')]
    numbers_sum = sum(numbers)

    print(numbers_sum)
