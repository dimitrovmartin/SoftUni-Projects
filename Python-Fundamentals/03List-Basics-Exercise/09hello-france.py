clothes = input().split("|")
budget = float(input())

bought_clothes_prices = []

for dress in clothes:
    dress_data = dress.split("->")
    type_of_dress = dress_data[0]
    dress_price = float(dress_data[1])

    if budget - dress_price >= 0:
        if type_of_dress == "Clothes" and dress_price <= 50.00 or \
                type_of_dress == "Shoes" and dress_price <= 35.00 or \
                type_of_dress == "Accessories" and dress_price <= 20.50:
            budget -= dress_price
            bought_clothes_prices.append(dress_price)

total_cost = sum(bought_clothes_prices)

bought_clothes_prices = [x * 1.40 for x in bought_clothes_prices]

total_money = sum(bought_clothes_prices)
money_earned = total_money - total_cost

for dress in bought_clothes_prices:
    print(f"{dress:.2f} ", end='')

print()
print(f"Profit: {money_earned:.2f}")

if total_money + budget >= 150:
    print("Hello, France!")
else:
    print("Time to go.")
