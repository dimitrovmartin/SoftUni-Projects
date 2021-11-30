from project.astronaut.astronaut import Astronaut


class Meteorologist(Astronaut):
    DEFAULT_OXYGEN = 90
    DEFAULT_BREATH = 15

    def __init__(self, name):
        super().__init__(name, self.DEFAULT_OXYGEN)

