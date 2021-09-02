# Every fifth day you buy Tree Lights quantity of times and increase your Christmas spirit by 17. If you have bought Tree Skirts and Tree Garlands at the same day you additionally increase your spirit by 30.
# Every tenth day you lose 20 spirit, because your cat ruins all tree decorations, and you should rebuild the tree and buy one piece of tree skirt, garlands, and lights. That is why you are forced to increase the allowed quantity with 2 at the beginning of every eleventh day.
# Also, if the last day is a tenth day the cat decides to demolish even more and ruins the Christmas turkey, and you lose additional 30 spirit.
# At the end you must print the total cost and the gained spirit.

quantity = int(input())
days = int(input())

total_price = 0
christmas_spirit = 0

ornament_set_price = 2
tree_skirt_price = 5
tree_garlands_price = 3
tree_lights_price = 15

for i in range(1, days + 1):
    if i % 11 == 0:
        quantity += 2
    if i % 2 == 0:
        total_price += ornament_set_price * quantity
        christmas_spirit += 5
    if i % 3 == 0:
        total_price += tree_skirt_price * quantity + tree_garlands_price * quantity
        christmas_spirit += 13
    if i % 5 == 0:
        total_price += tree_lights_price * quantity
        christmas_spirit += 17
        if i % 3 == 0:
            christmas_spirit += 30
    if i % 10 == 0:
        total_price += (tree_skirt_price + tree_garlands_price + tree_lights_price)
        christmas_spirit -= 20
        if i == days:
            christmas_spirit -= 30

print(f"Total cost: {total_price}")
print(f"Total spirit: {christmas_spirit}")
