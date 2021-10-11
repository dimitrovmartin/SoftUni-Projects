# 57/100

def is_valid_coordinates(row, col, n):
    return 0 <= row < n and 0 <= col < n


rows = 7
cols = 7

player_one, player_two = input().split(', ')
player_one_score, player_two_score = 501, 501
player_one_throws, player_two_throws = 0, 0

matrix = []

for _ in range(rows):
    matrix.append(input().split())

current_player, other_player = player_one, player_two

winner = None

while True:
    row_data, col_data = input().split(', ')
    row = int(row_data[1:])
    col = int(col_data[:-1])

    points = 0

    if not is_valid_coordinates(row, col, rows):
        continue

    hitted_position = matrix[row][col]
    if current_player == player_one:
        player_one_throws += 1
    else:
        player_two_throws += 1

    if hitted_position.isnumeric():
        points = int(hitted_position)
    elif hitted_position == 'D':
        points = (int(matrix[row][0]) + int(matrix[row][-1]) + int(matrix[0][col]) + int(matrix[-1][col])) * 2
    elif hitted_position == 'T':
        points = (int(matrix[row][0]) + int(matrix[row][-1]) + int(matrix[0][col]) + int(matrix[-1][col])) * 3
    elif hitted_position == 'B':
        winner = current_player
        break

    if current_player == player_one:
        player_one_score -= points
    else:
        player_two_score -= points

    if player_one_score <= 0 or player_two_score <= 0:
        winner = current_player
        break

    current_player, other_player = other_player, current_player

winner_throws = player_one_throws if winner == player_one else player_two_throws

print(f'{winner} won the game with {winner_throws} throws!')