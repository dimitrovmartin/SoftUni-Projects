def is_valid_length(password : str):
    if 6 <= len(password) <= 10:
        return True
    else:
        return False


def are_symbols_valid(password: str):
    for symbol in password:
        if symbol.isdigit() or symbol.isalpha():
            continue
        else:
            return False

    return True


def does_contains_two_digits(password: str):
    digits = 0

    for symbol in password:
        if symbol.isdigit():
            digits += 1

    if digits >= 2:
        return True
    else:
        return False


password = input()

if not is_valid_length(password):
    print("Password must be between 6 and 10 characters")

if not are_symbols_valid(password):
    print("Password must consist only of letters and digits")

if not does_contains_two_digits(password):
    print("Password must have at least 2 digits")

if is_valid_length(password) and are_symbols_valid(password) and does_contains_two_digits(password):
    print("Password is valid")

