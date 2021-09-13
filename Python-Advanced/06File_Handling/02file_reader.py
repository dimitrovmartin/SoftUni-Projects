try:
    file = open("numbers.txt", "r")
    numbers = file.readlines()
    numbers = [int(number) for number in numbers]

    numbers_sum = sum(numbers)

    print(numbers_sum)
except FileNotFoundError:
    print("File not found")