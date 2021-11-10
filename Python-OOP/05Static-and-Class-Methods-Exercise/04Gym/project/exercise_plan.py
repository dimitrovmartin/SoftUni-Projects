class ExercisePlan:
    id = 1

    def __init__(self, trainer_id: int, equipment_id: int, duration: int):
        self.trainer_id = trainer_id
        self.equipment_id = equipment_id
        self.duration = duration
        self.id = self.get_next_id()

    @classmethod
    def get_next_id(cls):
        current_id = cls.id
        cls.id += 1
        return current_id

    @classmethod
    def from_hours(cls, trainer_id: int, equipment_id: int, hours: int):
        minutes_from_hours = hours * 60

        return cls(trainer_id, equipment_id, minutes_from_hours)

    def __repr__(self):
        return f"Plan <{self.id}> with duration {self.duration} minutes"


