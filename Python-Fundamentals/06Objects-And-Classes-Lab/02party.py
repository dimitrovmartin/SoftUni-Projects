class Party:
    def __init__(self):
        self.__guests = []

    def add_guest(self, guest):
        self.__guests.append(guest)

    def __get_guests_count(self):
        return len(self.__guests)

    def __repr__(self):
        return f"Going: {', '.join(self.__guests)}\nTotal: {self.__get_guests_count()}"


party = Party()

name = input()

while not name == "End":
    party.add_guest(name)

    name = input()

print(party)


