from project.animals.animal import Mammal


class Mouse(Mammal):
    SOUND = 'Squeak'
    ALLOWED_FOODS = ['Vegetable', 'Fruit']
    WEIGHT_GAIN = 0.1

    def __init__(self, name, weight, living_region):
        super().__init__(name, weight, living_region)


class Dog(Mammal):
    SOUND = 'Woof!'
    ALLOWED_FOODS = ['Meat']
    WEIGHT_GAIN = 0.4

    def __init__(self, name, weight, living_region):
        super().__init__(name, weight, living_region)


class Cat(Mammal):
    SOUND = 'Meow'
    ALLOWED_FOODS = ['Vegetable', 'Meat']
    WEIGHT_GAIN = 0.3

    def __init__(self, name, weight, living_region):
        super().__init__(name, weight, living_region)


class Tiger(Mammal):
    SOUND = 'ROAR!!!'
    ALLOWED_FOODS = ['Meat']
    WEIGHT_GAIN = 1

    def __init__(self, name, weight, living_region):
        super().__init__(name, weight, living_region)
