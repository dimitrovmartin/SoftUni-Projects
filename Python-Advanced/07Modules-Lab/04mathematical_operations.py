from math_helper import get_math_operation

first_number, sign, second_number = input().split()

result = get_math_operation(sign)(int(first_number), int(second_number))

print(result)

