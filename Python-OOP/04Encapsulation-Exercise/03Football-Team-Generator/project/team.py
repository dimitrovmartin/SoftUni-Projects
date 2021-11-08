class Team:
    def __init__(self, name, rating):
        self.__name = name
        self.__rating = rating
        self.__players = []

    def add_player(self, new_player):
        if new_player in self.__players:
            return f'Player {new_player.name} has already joined'

        self.__players.append(new_player)
        return f'Player {new_player.name} joined team {self.__name}'

    def remove_player(self, player_name):
        for player in self.__players:
            if player.name == player_name:
                self.__players.remove(player)
                return player

        return f'Player {player_name} not found'

