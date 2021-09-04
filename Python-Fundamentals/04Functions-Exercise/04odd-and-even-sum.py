def get_even_sum(number_as_string):
    even_sum = 0

    for char in number_as_string:
        digit = int(char)

        if digit % 2 == 0:
            even_sum += digit

    return even_sum


def get_odd_sum(number_as_string):
    odd_sum = 0

    for char in number_as_string:
        digit = int(char)

        if not digit % 2 == 0:
            odd_sum += digit

    return odd_sum


number_as_string = input()
