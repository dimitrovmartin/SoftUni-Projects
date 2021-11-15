from project.cat import Cat


class Kitten(Cat):
    SOUND = 'Meow'
    GENDER = 'Female'

    def __init__(self, name, age):
        super().__init__(name, age, self.GENDER)
