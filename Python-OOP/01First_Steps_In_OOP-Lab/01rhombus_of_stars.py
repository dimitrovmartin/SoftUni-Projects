def print_rhombus(n: int):
    def print_line(i, trend: int):

        if i == 0:
            return

        line: str = ' ' * (n-i) + '* ' * i
        print(line.rstrip())

        if i == n:
            trend = -1

        print_line(i+trend, trend)

    print_line(1, 1)


n = int(input())

print_rhombus(n)
