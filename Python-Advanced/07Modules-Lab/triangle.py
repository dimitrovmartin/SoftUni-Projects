def print_top(n):
    for i in range(1, n + 1):
        for j in range(1, i + 1):
            print(f"{j} ", end="")
        print()


def print_bottom(n):
    for i in range(n, 1, -1):
        for j in range(1, i):
            print(f"{j} ", end="")
        print()


def print_triangle(n):
    print_top(n)
    print_bottom(n)
