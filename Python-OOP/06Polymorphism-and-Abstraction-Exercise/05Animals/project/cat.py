from project.animal import Animal


class Cat(Animal):
    SOUND = 'Meow meow!'

    def __init__(self, name, age, gender):
        super().__init__(name, age, gender)
