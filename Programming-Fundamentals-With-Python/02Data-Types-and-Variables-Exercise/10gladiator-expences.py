lost_fights_count = int(input())
helmet_price = float(input())
sword_price = float(input())
shield_price = float(input())
armor_price = float(input())

broken_helmets = 0
broken_swords = 0
broken_shields = 0
broken_armors = 0

for i in range(1, lost_fights_count + 1):
    if i % 2 == 0:
        broken_helmets += 1
    if i % 3 == 0:
        broken_swords += 1
        if i % 2 == 0:
            broken_shields += 1
            if broken_shields % 2 == 0:
                broken_armors += 1

gladiator_expenses = broken_helmets * helmet_price + broken_swords * sword_price + broken_shields * shield_price + broken_armors * armor_price

print(f"Gladiator expenses: {gladiator_expenses:.2f} aureus")
