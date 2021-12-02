from project.appliances.tv import TV
from project.rooms.room import Room


class AloneYoung(Room):
    def __init__(self, name, salary):
        super().__init__(name, salary, 1)
        self.room_cost = 10
        self.appliances = [TV()]
        self.calculate_expenses(*self.appliances)
