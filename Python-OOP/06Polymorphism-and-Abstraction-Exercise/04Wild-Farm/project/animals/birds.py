from project.animals.animal import Bird


class Owl(Bird):
    SOUND = 'Hoot Hoot'
    ALLOWED_FOODS = ['Meat']
    WEIGHT_GAIN = 0.25

    def __init__(self, name, weight, wing_size):
        super().__init__(name, weight, wing_size)


class Hen(Bird):
    SOUND = 'Cluck'
    ALLOWED_FOODS = ['Vegetable', 'Fruit', 'Meat', 'Seed']
    WEIGHT_GAIN = 0.35

    def __init__(self, name, weight, wing_size):
        super().__init__(name, weight, wing_size)
