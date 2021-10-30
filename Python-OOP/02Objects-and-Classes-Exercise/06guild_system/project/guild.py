from project.player import Player


class Guild:
    def __init__(self, name):
        self.name = name
        self.players = []

    def assign_player(self, player: Player):
        if player.guild == self.name:
            return f'Player {player.name} is already in the guild.'

        if not player.guild == Player.default_guild:
            return f'Player {player.name} is in another guild.'

        self.players.append(player)
        player.guild = self.name
        return f'Welcome player {player.name} to the guild {self.name}'

    def kick_player(self, player_name):
        for player in self.players:
            if player.name == player.name:
                player.guild = Player.default_guild
                return f'Player {player_name} has been removed from the guild.'

        return f'Player {player_name} is not in the guild.'

    def guild_info(self):
        info = [f'Guild: {self.name}']
        [info.append(player.player_info()) for player in self.players]

        return '\n'.join(info)
