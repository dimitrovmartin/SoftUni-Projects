class AstronautRepository:
    def __init__(self):
        self.astronauts = []

    def add(self, astronaut):
        self.astronauts.append(astronaut)

    def remove(self, astronaut):
        self.astronauts.remove(astronaut)

    def find_by_name(self, name):
        for astronaut in self.astronauts:
            if astronaut.name == name:
                return astronaut
        return None

    def find_astronauts_for_mission(self):
        astronauts = list(sorted([astronaut for astronaut in self.astronauts
                                  if astronaut.oxygen > 30],
                                 key=lambda x: x.oxygen, reverse=True))[0:5]
        return astronauts
