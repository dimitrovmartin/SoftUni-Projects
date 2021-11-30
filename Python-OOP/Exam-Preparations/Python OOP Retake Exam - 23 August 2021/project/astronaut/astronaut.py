from abc import ABC, abstractmethod


class Astronaut(ABC):
    DEFAULT_BREATH = 10
    @abstractmethod
    def __init__(self, name, oxygen):
        self.name = name
        self.oxygen = oxygen
        self.backpack = []

    @property
    def name(self):
        return self.__name

    @name.setter
    def name(self, value):
        if not value or not value.strip():
            raise ValueError('Astronaut name cannot be empty string or whitespace!')
        self.__name = value

    def breathe(self):
        self.oxygen -= self.DEFAULT_BREATH

    def increase_oxygen(self, amount):
        self.oxygen += amount
