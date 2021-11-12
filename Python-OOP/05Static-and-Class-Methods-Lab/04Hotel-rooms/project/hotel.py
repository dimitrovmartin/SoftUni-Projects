class Hotel:
    def __init__(self, name):
        self.name = name
        self.rooms = []

    @property
    def guests(self):
        return self.__get_guests()

    @classmethod
    def from_stars(cls, stars_count: int):
        name = f"{stars_count} stars Hotel"

        return cls(name)

    def add_room(self, room):
        if room in self.rooms:
            return

        self.rooms.append(room)

    def take_room(self, room_number, people):
        for room in self.rooms:
            if room.number == room_number:
                room.take_room(people)
                return

    def free_room(self, room_number):
        for room in self.rooms:
            if room.number == room_number:
                room.free_room()

    def __get_guests(self):
        return sum(room.guests for room in self.rooms)

    def status(self):
        free_rooms = ', '.join(str(room.number) for room in self.rooms if not room.is_taken)
        taken_rooms = ', '.join(str(room.number) for room in self.rooms if room.is_taken)

        return f'Hotel {self.name} has {self.guests} total guests\nFree rooms: {free_rooms}\nTaken rooms: {taken_rooms}'

