def is_valid_index(row, col, size, chessboard):
    return 0 <= row < size and 0 <= col < size and chessboard[row][col] == 'K'


def get_kills_count(row, col, chessboard):
    size = len(chessboard)
    counter = 0

    if is_valid_index(row - 2, col - 1, size, chessboard):
        counter += 1
    if is_valid_index(row - 2, col + 1, size, chessboard):
        counter += 1
    if is_valid_index(row - 1, col - 2, size, chessboard):
        counter += 1
    if is_valid_index(row - 1, col + 2, size, chessboard):
        counter += 1
    if is_valid_index(row + 1, col - 2, size, chessboard):
        counter += 1
    if is_valid_index(row + 1, col + 2, size, chessboard):
        counter += 1
    if is_valid_index(row + 2, col - 1, size, chessboard):
        counter += 1
    if is_valid_index(row + 2, col + 1, size, chessboard):
        counter += 1

    return counter


n = int(input())

chessboard = []

are_killers_gone = False
killers = 0

for row in range(n):
    elements = list(input())
    chessboard.append(elements)

while not are_killers_gone:
    killer_row, killer_col, max_kills, count_kills = 0, 0, 0, 0


    for row in range(n):
        for col in range(n):
            if chessboard[row][col] == 'K':
                count_kills = get_kills_count(row, col, chessboard)

                if count_kills > max_kills:
                    killer_row, killer_col, max_kills = row, col, count_kills

    if max_kills == 0:
        are_killers_gone = True
        break
    else:
        chessboard[killer_row][killer_col] = '0'
        killers += 1

print(killers)
