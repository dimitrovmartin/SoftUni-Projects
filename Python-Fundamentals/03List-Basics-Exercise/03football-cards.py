team_a = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
team_b = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]

is_game_terminated = False

cards = input().split()

for card in cards:
    card_info = card.split("-")
    team = card_info[0]
    player_number = int(card_info[1])

    if team == "A":
        if player_number in team_a:
            team_a.remove(player_number)
    elif team == "B":
        if player_number in team_b:
            team_b.remove(player_number)

    if len(team_a) < 7 or len(team_b) < 7:
        is_game_terminated = True
        break

print(f"Team A - {len(team_a)}; Team B - {len(team_b)}")

if is_game_terminated:
    print("Game was terminated")
