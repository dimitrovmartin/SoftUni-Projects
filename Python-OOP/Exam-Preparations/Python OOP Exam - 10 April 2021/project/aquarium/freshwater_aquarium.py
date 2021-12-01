from project.aquarium.base_aquarium import BaseAquarium


class FreshwaterAquarium(BaseAquarium):
    def __init__(self, name):
        super().__init__(name, 50)

    def add_fish(self, fish):
        if fish.__class__.__name__ == 'FreshwaterFish':
            return super().add_fish(fish)
        return "Water not suitable."
