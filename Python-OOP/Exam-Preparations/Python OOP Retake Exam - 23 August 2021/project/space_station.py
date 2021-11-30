from project.astronaut.astronaut import Astronaut
from project.astronaut.astronaut_repository import AstronautRepository
from project.astronaut.biologist import Biologist
from project.astronaut.geodesist import Geodesist
from project.astronaut.meteorologist import Meteorologist
from project.planet.planet import Planet
from project.planet.planet_repository import PlanetRepository


class SpaceStation:
    def __init__(self):
        self.planet_repository = PlanetRepository()
        self.astronaut_repository = AstronautRepository()
        self.successful_missions = 0
        self.unsuccessful_missions = 0

    def add_astronaut(self, astronaut_type, name):
        if self.astronaut_repository.find_by_name(name):
            return f'{name} is already added'

        if astronaut_type == 'Biologist':
            self.astronaut_repository.add(Biologist(name))
        elif astronaut_type == 'Geodesist':
            self.astronaut_repository.add(Geodesist(name))
        elif astronaut_type == 'Meteorologist':
            self.astronaut_repository.add(Meteorologist(name))
        else:
            raise Exception('Astronaut type is not valid!')
        return f'Successfully added {astronaut_type}: {name}.'

    def add_planet(self, name, items):
        if self.planet_repository.find_by_name(name):
            return f"{name} is already added."

        items = items.split(', ')

        planet = Planet(name)
        planet.items = items

        self.planet_repository.add(planet)
        return f'Successfully added Planet: {name}.'

    def retire_astronaut(self, name):
        astronaut = self.astronaut_repository.find_by_name(name)

        if not astronaut:
            raise Exception(f"Astronaut {name} doesn't exist!")

        self.astronaut_repository.remove(astronaut)

        return f"Astronaut {name} was retired!"

    def recharge_oxygen(self):
        for astronaut in self.astronaut_repository.astronauts:
            astronaut.increase_oxygen(10)

    def send_on_mission(self, planet_name):
        planet = self.planet_repository.find_by_name(planet_name)

        if not planet:
            raise Exception('Invalid planet name!')

        astronauts = [astronaut for astronaut in self.astronaut_repository.astronauts if astronaut.oxygen > 30]

        if not astronauts:
            raise Exception('You need at least one astronaut to explore the planet!')

        astronauts = list(sorted(astronauts, key=lambda x: x.oxygen, reverse=True))

        first_five = []
        [first_five.append(astronaut) for astronaut in astronauts if len(first_five) <= 5]

        for astronaut in first_five:
            while astronaut.oxygen > 0:
                if planet.items:
                    astronaut.backpack.append(planet.items.pop())
                    astronaut.breathe()
                else:
                    self.successful_missions += 1
                    return f"Planet: {planet_name} was explored. {len(first_five)} astronauts participated in collecting items."

        if planet.items:
            self.unsuccessful_missions += 1
            return 'Mission is not completed.'
        else:
            self.successful_missions += 1
            return f"Planet: {planet_name} was explored. {len(first_five)} astronauts participated in collecting items."

    def report(self):
        report = []
        report.append(f'{self.successful_missions} successful missions!')
        report.append(f'{self.unsuccessful_missions} missions were not completed!')
        report.append('Astronauts\' info:')

        for astronaut in self.astronaut_repository.astronauts:
            report.append(f'Name: {astronaut.name}')
            report.append(f'Oxygen: {astronaut.oxygen}')
            items = ', '.join(item for item in astronaut.backpack) if astronaut.backpack else 'none'
            report.append(f"Backpack items: {items}")

        return '\n'.join(report)
