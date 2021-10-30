class Player:
    default_guild = 'Unaffiliated'

    def __init__(self, name, hp, mp):
        self.name = name
        self.hp = hp
        self.mp = mp
        self.skills = {}
        self.guild = Player.default_guild

    def add_skill(self, skill, mana_cost):
        if skill in self.skills.keys():
            return 'Skill already added'

        self.skills[skill] = mana_cost
        return f'Skill {skill} added to the collection of the player {self.name}'

    def player_info(self):
        info = [f'Name: {self.name}', f'Guild: {self.guild}', f'HP: {self.hp}', f'MP: {self.mp}']
        [info.append(f'==={skill} - {mana}') for skill, mana in self.skills.items()]

        return '\n'.join(info) + '\n'
