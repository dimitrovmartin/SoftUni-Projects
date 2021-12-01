from project.aquarium.base_aquarium import BaseAquarium


class SaltwaterAquarium(BaseAquarium):
    def __init__(self, name):
        super().__init__(name, 25)

    def add_fish(self, fish):
        if fish.__class__.__name__ == 'SaltwaterFish':
            return super().add_fish(fish)
        return "Water not suitable."

