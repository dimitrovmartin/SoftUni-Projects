def get_factorial_division(first_number : int, second_number: int):
    def get_factorial(number: int):
        factorial = 1

        for i in range(1, number + 1):
            factorial *= i

        return factorial

    first_factorial = get_factorial(first_number)
    second_factorial = get_factorial(second_number)

    return first_factorial / second_factorial


first_number = int(input())
second_number = int(input())

factorial_division = get_factorial_division(first_number, second_number)

print(f"{factorial_division:.2f}")
