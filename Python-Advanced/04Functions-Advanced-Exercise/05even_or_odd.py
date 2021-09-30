def even_odd(*args):
    command = args[-1]
    parity = 0 if command == 'even' else 1

    return [int(x) for x in args[:-1] if x % 2 == parity]


print(even_odd(1, 2, 3, 4, 5, 6, "even"))
