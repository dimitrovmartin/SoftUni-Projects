from project.appliances.fridge import Fridge
from project.appliances.laptop import Laptop
from project.appliances.tv import TV
from project.rooms.room import Room


class YoungCouple(Room):
    def __init__(self, name, salary_one, salary_two):
        super().__init__(name, salary_one + salary_two, 2)
        self.room_cost = 20
        self.appliances = [TV(), TV(), Laptop(), Laptop(), Fridge(), Fridge()]
        self.calculate_expenses(*self.appliances)
