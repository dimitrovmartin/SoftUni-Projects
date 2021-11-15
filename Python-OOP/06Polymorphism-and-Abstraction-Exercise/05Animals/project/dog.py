from project.animal import Animal


class Dog(Animal):
    SOUND = 'Woof!'

    def __init__(self, name, age, gender):
        super().__init__(name, age, gender)

