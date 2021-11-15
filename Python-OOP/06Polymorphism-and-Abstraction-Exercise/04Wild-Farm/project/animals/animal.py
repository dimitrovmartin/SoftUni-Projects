from abc import ABC, abstractmethod


class Animal(ABC):
    SOUND = ''
    ALLOWED_FOODS = []
    WEIGHT_GAIN = 0

    @abstractmethod
    def __init__(self, name, weight):
        self.name = name
        self.weight = weight
        self.food_eaten = 0

    def make_sound(self):
        return self.SOUND

    def feed(self, food):
        food_name = food.__class__.__name__

        if food_name not in self.ALLOWED_FOODS:
            return f"{self.__class__.__name__} does not eat {food_name}!"

        self.weight += self.WEIGHT_GAIN * food.quantity
        self.food_eaten += food.quantity


class Bird(Animal, ABC):
    @abstractmethod
    def __init__(self, name, weight, wing_size):
        super().__init__(name, weight)
        self.wing_size = wing_size

    def __str__(self):
        return f'{self.__class__.__name__} [{self.name}, {self.wing_size}, {self.weight}, {self.food_eaten}]'


class Mammal(Animal, ABC):
    @abstractmethod
    def __init__(self, name, weight, living_region):
        super().__init__(name, weight)
        self.living_region = living_region

    def __str__(self):
        return f"{self.__class__.__name__} [{self.name}, {self.weight}, {self.living_region}, {self.food_eaten}]"
