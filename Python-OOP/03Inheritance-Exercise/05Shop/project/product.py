class Product:
    def __init__(self, name, quantity):
        self.name = name
        self.quantity = quantity

    def decrease(self, amount):
        if self.quantity >= amount:
            self.quantity -= amount

    def increase(self, amount):
        self.quantity += amount

    def __repr__(self):
        return self.name
