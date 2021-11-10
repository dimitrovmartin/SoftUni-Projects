class Equipment:
    id = 1

    def __init__(self, name):
        self.name = name
        self.id = self.get_next_id()

    @classmethod
    def get_next_id(cls):
        current_id = cls.id
        cls.id += 1
        return current_id

    def __repr__(self):
        return f"Equipment <{self.id}> {self.name}"
