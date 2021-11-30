from project.astronaut.astronaut import Astronaut


class Biologist(Astronaut):
    DEFAULT_OXYGEN = 70
    DEFAULT_BREATH = 5

    def __init__(self, name):
        super().__init__(name, self.DEFAULT_OXYGEN)

