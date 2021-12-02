from project.appliances.fridge import Fridge
from project.appliances.stove import Stove
from project.appliances.tv import TV
from project.rooms.room import Room


class OldCouple(Room):
    def __init__(self, name, pension_one, pension_two):
        super().__init__(name, pension_one + pension_two, 2)
        self.room_cost = 15
        self.appliances = [TV(), TV(), Fridge(), Fridge(), Stove(), Stove()]
        self.calculate_expenses(*self.appliances)
