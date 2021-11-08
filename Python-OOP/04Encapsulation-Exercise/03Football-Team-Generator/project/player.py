class Player:
    def __init__(self, name, sprint, dribble, passing, shooting):
        self.name = name
        self.__sprint = sprint
        self.__dribble = dribble
        self.__passing = passing
        self.__shooting = shooting

    @property
    def name(self):
        return self.__name

    @name.setter
    def name(self, value):
        self.__name = value

    def __str__(self):
        info = f'Player: {self.name}' + '\n'
        info += f'Sprint: {self.__sprint}' + '\n'
        info += f'Dribble: {self.__dribble}' + '\n'
        info += f'Passing: {self.__passing}' + '\n'
        info += f'Shooting: {self.__shooting}'

        return info
