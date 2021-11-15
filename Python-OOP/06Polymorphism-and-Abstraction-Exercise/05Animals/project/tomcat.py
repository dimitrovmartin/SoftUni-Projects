from project.cat import Cat


class Tomcat(Cat):
    SOUND = 'Hiss'
    GENDER = 'Male'

    def __init__(self, name, age):
        super().__init__(name, age, self.GENDER)

