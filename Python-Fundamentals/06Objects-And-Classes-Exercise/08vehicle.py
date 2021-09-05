class Vehicle:
    owner = None

    def __init__(self, type: str, model: str, price: int):
        self.type = type
        self.model = model
        self.price = price

    def buy(self, money, owner):
        if self.owner is not None:
            return "Car already sold"
        elif money < self.price:
            return "Sorry, not enough money"
        else:
            self.owner = owner
            return f"Successfully bought a {self.type}. Change: {money - self.price:.2f}"

    def sell(self):
        if self.owner is None:
            return "Vehicle has no owner"
        else:
            self.owner = None

    def __repr__(self):
        if self.owner is None:
            return  f"{self.model} {self.type} is on sale: {self.price}"
        else:
            return f"{self.model} {self.type} is owned by: {self.owner}"


vehicle_type = "car"
model = "BMW"
price = 30000
vehicle = Vehicle(vehicle_type, model, price)
print(vehicle.buy(15000, "Peter"))
print(vehicle.buy(35000, "George"))
print(vehicle)
vehicle.sell()
print(vehicle)
