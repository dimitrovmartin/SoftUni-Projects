class Product:
    def __init__(self, price: float, quantity):
        self.price = price
        self.quantity = quantity

products_by_price = {}

line = input()

while not line == "buy":
    product_name, product_price, product_quantity = line.split()

    if product_name in products_by_price.keys():
        products_by_price[product_name].price = float(product_price)
        products_by_price[product_name].quantity += int(product_quantity)
    else:
        products_by_price[product_name] = Product(float(product_price), int(product_quantity))

    line = input()

for key, value in products_by_price.items():
    print(f"{key} -> {value.price * value.quantity:.2f}")
