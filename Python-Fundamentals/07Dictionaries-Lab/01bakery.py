products_by_price = {}

products_data = input().split()

for i in range(0, len(products_data), 2):
    key = products_data[i]
    value = products_data[i + 1]

    products_by_price[key] = int(value)

print(products_by_price)