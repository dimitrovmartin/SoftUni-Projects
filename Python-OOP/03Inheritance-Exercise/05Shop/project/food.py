from project.product import Product


class Food(Product):
    DEFAULT_QUANTITY = 15

    def __init__(self, name):
        super().__init__(name, Food.DEFAULT_QUANTITY)
