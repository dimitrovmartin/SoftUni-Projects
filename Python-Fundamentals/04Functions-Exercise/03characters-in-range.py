def get_characters_in_range(first_char: str, second_char: str):
    first_char_as_int = ord(first_char)
    second_char_as_int = ord(second_char)

    result = ""

    for i in range(first_char_as_int + 1, second_char_as_int):
        result += chr(i) + " "

    return result


first_char = input()
second_char = input()

characters_in_range = get_characters_in_range(first_char, second_char)

print(characters_in_range)
