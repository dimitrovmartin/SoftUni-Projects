for _ in range(3):
    numbers_list = [int(number) for number in input().split(", ")]
    result = 1

    for number in numbers_list:
        if number <= 5:
            result *= number
        elif number > 5:
            result /= number

    print(f"{round(result)}")
