class AstronautRepository:
    def __init__(self):
        self.astronauts = []

    def add(self, astronaut):
        self.astronauts.append(astronaut)

    def remove(self, astronaut):
        if astronaut in self.astronauts:
            self.astronauts.remove(astronaut)

    def find_by_name(self, name):
        astronaut = [astronaut for astronaut in self.astronauts if astronaut.name == name]

        if astronaut:
            return astronaut[0]


