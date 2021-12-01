from abc import ABC, abstractmethod

from project.common.validator import Validator


class BaseAquarium(ABC):
    @abstractmethod
    def __init__(self, name, capacity):
        self.name = name
        self.capacity = capacity
        self.decorations = []
        self.fish = []

    @property
    def name(self):
        return self.__name

    @name.setter
    def name(self, value):
        Validator.raise_if_str_is_empty_or_whitespace(value, "Aquarium name cannot be an empty string.")
        self.__name = value

    def calculate_comfort(self):
        return sum(decoration.comfort for decoration in self.decorations)

    def add_fish(self, fish):
        if len(self.fish) == self.capacity:
            return "Not enough capacity."

        self.fish.append(fish)
        return f"Successfully added {fish.__class__.__name__} to {self.name}."

    def remove_fish(self, fish):
        self.fish.remove(fish)

    def add_decoration(self, decoration):
        self.decorations.append(decoration)

    def feed(self):
        for fish in self.fish:
            fish.eat()

    def __str__(self):
        result = 'none'

        if self.fish:
            result = ' '.join(fish.name for fish in self.fish)

        return f"{self.name}:\nFish: {result}\nDecorations: {len(self.decorations)}\nComfort: {self.calculate_comfort()}"
