from project.astronaut.astronaut import Astronaut


class Geodesist(Astronaut):
    DEFAULT_OXYGEN = 50

    def __init__(self, name):
        super().__init__(name, self.DEFAULT_OXYGEN)
