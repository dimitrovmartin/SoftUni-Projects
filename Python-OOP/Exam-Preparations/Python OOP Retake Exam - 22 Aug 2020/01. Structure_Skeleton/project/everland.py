class Everland:
    def __init__(self):
        self.rooms = []

    def add_room(self, room):
        self.rooms.append(room)

    def get_monthly_consumptions(self):
        monthly_consumptions = 0

        for room in self.rooms:
            monthly_consumptions += room.expenses + room.room_cost

        return f"Monthly consumption: {monthly_consumptions:.2f}$."

    def pay(self):
        result = []
        unpayed_rooms = []

        for room in self.rooms:
            cost = room.expenses + room.room_cost
            if room.budget >= cost:
                room.budget -= cost
                result.append(f"{room.family_name} paid {cost:.2f}$ and have {room.budget:.2f}$ left.")
            else:
                unpayed_rooms.append(room)
                result.append(f"{room.family_name} does not have enough budget and must leave the hotel.")

        for room in unpayed_rooms:
            self.rooms.remove(room)
        return '\n'.join(result)

    def status(self):
        result = [f'Total population: {sum(room.members_count for room in self.rooms)}']

        for room in self.rooms:
            result.append(str(room))

        return '\n'.join(result)