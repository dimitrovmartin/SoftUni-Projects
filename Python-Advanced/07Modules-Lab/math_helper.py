from math_functions import add_numbers, subtract_numbers, multiply_numbers, divide_numbers, raise_number


def get_math_operation(sign):
    operations = {
        "+": add_numbers,
        "-": subtract_numbers,
        "*": multiply_numbers,
        "/": divide_numbers,
        "^": raise_number
    }

    return operations[sign]
