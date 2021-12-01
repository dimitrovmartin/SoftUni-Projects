from project.aquarium.freshwater_aquarium import FreshwaterAquarium
from project.aquarium.saltwater_aquarium import SaltwaterAquarium
from project.decoration.decoration_repository import DecorationRepository
from project.decoration.ornament import Ornament
from project.decoration.plant import Plant
from project.fish.freshwater_fish import FreshwaterFish
from project.fish.saltwater_fish import SaltwaterFish


class Controller:
    def __init__(self):
        self.decorations_repository = DecorationRepository()
        self.aquariums = []

    def add_aquarium(self, aquarium_type, aquarium_name):
        aquarium = self.__create_aquarium(aquarium_type, aquarium_name)

        if aquarium is None:
            return "Invalid aquarium type."

        self.aquariums.append(aquarium)
        return f"Successfully added {aquarium_type}."

    def add_decoration(self, decoration_type):
        decoration = self.__create_decoration(decoration_type)

        if decoration is None:
            return "Invalid decoration type."

        self.decorations_repository.add(decoration)
        return f"Successfully added {decoration_type}."

    def insert_decoration(self, aquarium_name, decoration_type):
        aquarium = self.__get_aquarium(aquarium_name)

        decoration = self.decorations_repository.find_by_type(decoration_type)

        if decoration == 'None':
            return f"There isn't a decoration of type {decoration_type}."

        self.decorations_repository.remove(decoration)
        aquarium.add_decoration(decoration)

        return f"Successfully added {decoration_type} to {aquarium_name}."

    def add_fish(self, aquarium_name, fish_type, fish_name, fish_species, price):
        fish = self.__create_fish(fish_type, fish_name, fish_species, price)

        if fish is None:
            return f"There isn't a fish of type {fish_type}."

        aquarium = self.__get_aquarium(aquarium_name)
        return aquarium.add_fish(fish)

    def feed_fish(self, aquarium_name):
        aquarium = self.__get_aquarium(aquarium_name)

        aquarium.feed()

        return f"Fish fed: {len(aquarium.fish)}"

    def calculate_value(self, aquarium_name):
        aquarium = self.__get_aquarium(aquarium_name)

        aquarium_price = [fish.price for fish in aquarium.fish]
        decoration_price = [decoration.price for decoration in aquarium.decorations]

        total_price = 0

        if aquarium_price:
            total_price += sum(aquarium_price)

        if decoration_price:
            total_price += sum(decoration_price)

        return f'The value of Aquarium {aquarium_name} is {total_price:.2f}.'

    def report(self):
        report = ''

        for aquarium in self.aquariums:
            report += str(aquarium) + '\n'

        return report.strip()

    @staticmethod
    def __create_aquarium(aquarium_type, aquarium_name):
        if aquarium_type == 'FreshwaterAquarium':
            return FreshwaterAquarium(aquarium_name)
        elif aquarium_type == 'SaltwaterAquarium':
            return SaltwaterAquarium(aquarium_name)
        return None

    @staticmethod
    def __create_decoration(decoration_type):
        if decoration_type == 'Ornament':
            return Ornament()
        elif decoration_type == 'Plant':
            return Plant()
        return None

    def __get_aquarium(self, aquarium_name):
        for aquarium in self.aquariums:
            if aquarium.name == aquarium_name:
                return aquarium
        return None

    @staticmethod
    def __create_fish(fish_type, fish_name, fish_species, price):
        if fish_type == 'FreshwaterFish':
            return FreshwaterFish(fish_name, fish_species, price)
        elif fish_type == 'SaltwaterFish':
            return SaltwaterFish(fish_name, fish_species, price)
        return None
