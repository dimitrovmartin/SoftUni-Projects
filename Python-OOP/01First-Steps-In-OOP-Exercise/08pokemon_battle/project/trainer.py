from project.pokemon import Pokemon

class Trainer:
    def __init__(self, name):
        self.name = name
        self.pokemons = []

    def add_pokemon(self, pokemon : Pokemon):
        if any([x for x in self.pokemons if x.name == pokemon.name]):
            return "This pokemon is already caught"
        self.pokemons.append(pokemon)
        return f'Caught {pokemon.pokemon_details()}'

    def release_pokemon(self, pokemon_name):
        pokemon = [x for x in self.pokemons if pokemon_name == x.name]
        if not pokemon:
            return 'Pokemon is not caught'

        self.pokemons.remove(pokemon[0])
        return f"You have released {pokemon_name}"

    def trainer_data(self):
        data = []

        data.append(f'Pokemon Trainer {self.name}')
        data.append(f'Pokemon count {len(self.pokemons)}')
        [data.append(f'- {pokemon.pokemon_details()}') for pokemon in self.pokemons]

        return '\n'.join(data).strip()

