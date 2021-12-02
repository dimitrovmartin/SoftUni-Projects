from project.appliances.fridge import Fridge
from project.appliances.laptop import Laptop
from project.appliances.tv import TV
from project.rooms.room import Room


class YoungCoupleWithChildren(Room):
    def __init__(self, name, salary_one, salary_two, *children):
        super().__init__(name, salary_one + salary_two, 2 + len(children))
        self.room_cost = 30
        self.children = list(children)
        self.appliances = [TV(), Fridge(), Laptop(), TV(), Fridge(), Laptop()]
        for child in children:
            self.appliances += [TV(), Fridge(), Laptop()]
        self.calculate_expenses(*self.appliances, *self.children)
