class ProductRepository:
    def __init__(self):
        self.products = []

    def add(self, product):
        self.products.append(product)

    def find(self, product_name):
        searched_product = [product for product in self.products if product.name == product_name]

        if searched_product:
            return searched_product[0]

    def remove(self, product_name):
        searched_product = [product for product in self.products if product.name == product_name]

        if searched_product:
            self.products.remove(searched_product[0])

    def __repr__(self):
        info = [f'{product.name}: {product.quantity}' for product in self.products]
        return '\n'.join(info).rstrip()
