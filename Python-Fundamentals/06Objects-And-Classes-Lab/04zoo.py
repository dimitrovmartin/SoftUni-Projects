class Zoo:
    __animals = 0

    def __init__(self, name: str):
        self.name = name
        self.mammals = []
        self.fishes = []
        self.birds = []

    def add_animal(self, species, name):
        if species == "mammal":
            self.mammals.append(name)
        elif species == "fish":
            self.fishes.append(name)
        elif species == "bird":
            self.birds.append(name)

        self.__animals += 1

    def get_info(self, species: str):
        message = ""

        if species == "mammal":
            message += f"Mammals in {self.name}: {', '.join(self.mammals)}\n"
        elif species == "fish":
            message += f"Fishes in {self.name}: {', '.join(self.fishes)}\n"
        elif species == "bird":
            message += f"Birds in {self.name}: {', '.join(self.birds)}\n"

        message += f"Total animals: {self.__animals}"

        return message


zoo_name = input()
n = int(input())

zoo = Zoo(zoo_name)

for i in range(n):
    species, name = input().split()

    zoo.add_animal(species, name)

searched_species = input()

print(zoo.get_info(searched_species))
