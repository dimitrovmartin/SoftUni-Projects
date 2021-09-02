cards = input().split()
shuffles = int(input())

half_size = len(cards) // 2



for _ in range(shuffles):
    first_deck = cards[0:half_size]
    second_deck = cards[half_size:]
    faro_cards = []

    for i in range(len(first_deck)):
        faro_cards.append(first_deck[i])
        faro_cards.append(second_deck[i])

    cards = faro_cards

print(cards)

