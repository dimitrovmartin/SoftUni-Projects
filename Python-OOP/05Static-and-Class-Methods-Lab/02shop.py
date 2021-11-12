class Shop:
    def __init__(self, name, _type, capacity):
        self.name = name
        self.type = _type
        self.capacity = capacity
        self.items = {}

    @classmethod
    def small_shop(cls, name, _type):
        capacity = 10
        return cls(name, _type, capacity)

    def add_item(self, item_name):
        current_capacity = sum(item_price for item_price in self.items.values())

        if current_capacity == self.capacity:
            return 'Not enough capacity in the shop'

        if item_name not in self.items.keys():
            self.items[item_name] = 0

        self.items[item_name] += 1
        return f"{item_name} added to the shop"

    def remove_item(self, item_name, amount):
        if item_name not in self.items.keys() or self.items[item_name] < amount:
            return f'Cannot remove {amount} {item_name}'

        self.items[item_name] -= amount
        return f"{amount} {item_name} removed from the shop"

    def __repr__(self):
        return f"{self.name} of type {self.type} with capacity {self.capacity}"