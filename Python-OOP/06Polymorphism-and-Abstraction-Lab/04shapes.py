import math
from abc import ABC, abstractmethod


class Shape(ABC):
    @abstractmethod
    def calculate_area(self):
        pass

    @abstractmethod
    def calculate_perimeter(self):
        pass


class Circle(Shape):
    def __init__(self, r):
        self.r = r

    def calculate_area(self):
        return math.pi * self.r * self.r

    def calculate_perimeter(self):
        return math.pi * self.r * 2


class Rectangle(Shape):
    def __init__(self, a, b):
        self.a = a
        self.b = b

    def calculate_area(self):
        return self.a * self.b

    def calculate_perimeter(self):
        return (self.a * 2) + (self.b * 2)


circle = Circle(5)
print(circle.calculate_area())
print(circle.calculate_perimeter())

rectangle = Rectangle(10, 20)
print(rectangle.calculate_area())
print(rectangle.calculate_perimeter())
