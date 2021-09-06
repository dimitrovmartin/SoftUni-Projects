products_by_quantity = {}

products_data = input().split()
searched_products = input().split()

for i in range(0, len(products_data), 2):
    key = products_data[i]
    value = products_data[i + 1]

    products_by_quantity[key] = int(value)

for product in searched_products:
    if product in products_by_quantity.keys():
        print(f"We have {products_by_quantity[product]} of {product} left")
    else:
        print(f"Sorry, we don't have {product}")