def sum_numbers(first_num: int, second_num: int):
    return first_num + second_num


def subtract(first_sum: int, third_num: int):
    return first_sum - third_num


def add_and_subtract(first_number : int, second_number : int, third_number : int):
    first_sum = sum_numbers(first_number, second_number)

    result = subtract(first_sum, third_number)

    return result


first_num = int(input())
second_num = int(input())
third_num = int(input())

result = add_and_subtract(first_num, second_num, third_num)

print(result)


