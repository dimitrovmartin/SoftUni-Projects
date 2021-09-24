rows, cols = [int(x) for x in input().split()]

for row in range(rows):
    for col in range(cols):
        print(f"{chr(row + 97)}{chr(col + 97 + row)}{chr(row + 97)}", end=" ")
    print()


