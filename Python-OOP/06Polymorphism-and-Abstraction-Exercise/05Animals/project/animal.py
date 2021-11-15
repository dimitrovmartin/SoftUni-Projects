from abc import ABC, abstractmethod


class Animal(ABC):
    SOUND = ''

    @abstractmethod
    def __init__(self, name, age, gender):
        self.name = name
        self.age = age
        self.gender = gender

    def make_sound(self):
        return self.SOUND

    def __repr__(self):
        return f"This is {self.name}. {self.name} is a {self.age} year old {self.gender} {self.__class__.__name__}"