def is_palindrome(number):
    number_as_string = str(number)
    half_count = len(number_as_string) // 2

    counter = -1

    for i in range(0, half_count + 1):
        first_number = number_as_string[i]
        second_number = number_as_string[counter]

        if not first_number == second_number:
            return False

        counter -= 1

    return True


numbers = input().split(", ")

for number in numbers:
    print(is_palindrome(number))

