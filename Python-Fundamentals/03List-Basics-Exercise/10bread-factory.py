energy = 100
coins = 100
is_bankrupt = False

events = input().split("|")

for event in events:
    event_data = event.split("-")
    event = event_data[0]
    amount = int(event_data[1])

    if event == "rest":
        if energy + amount >= 100:
            amount = 100 - energy

        energy += amount

        print(f"You gained {amount} energy.")
        print(f"Current energy: {energy}.")
    elif event == "order":
        if energy - 30 >= 0:
            energy -= 30
            coins += amount

            print(f"You earned {amount} coins.")
        else:
            energy += 50
            print("You had to rest!")
    else:
        if coins - amount > 0:
            coins -= amount
            print(f"You bought {event}.")
        else:
            print(f"Closed! Cannot afford {event}.")

            is_bankrupt = True
            break

if not is_bankrupt:
    print("Day completed!")
    print(f"Coins: {coins}")
    print(f"Energy: {energy}")
