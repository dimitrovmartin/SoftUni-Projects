class Guitar:
    def play(self):
        return "Playing the guitar"


class Children:
    def play(self):
        return "Children are playing"


def start_playing(i_can_play):
    return i_can_play.play()


children = Children()
print(start_playing(children))
guitar = Guitar()
print(start_playing(guitar))
