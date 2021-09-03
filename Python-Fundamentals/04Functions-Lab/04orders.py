def get_product_price(product):
    if product == "coffee":
        return 1.50
    elif product == "water":
        return 1.00
    elif product == "coke":
        return 1.40
    elif product == "snacks":
        return 2.00


product_name = input()
quantity = int(input())

product_price = get_product_price(product_name)

total_price = product_price * quantity

print(f"{total_price:.2f}")
