class Room:
    def __init__(self, name, budget, members_count):
        self.family_name = name
        self.budget = budget
        self.members_count = members_count
        self.children = []
        self.appliances = []
        self.expenses = 0

    @property
    def expenses(self):
        return self.__expenses

    @expenses.setter
    def expenses(self, value):
        if value < 0:
            raise ValueError("Expenses cannot be negative")
        self.__expenses = value

    def calculate_expenses(self, *args):
        for arg in args:
            self.expenses += arg.get_monthly_expense()

    def __str__(self):
        result = []

        result.append(f'{self.family_name} with {self.members_count} members. Budget: {self.budget:.2f}$, Expenses: {self.expenses:.2f}$')
        for idx, child in enumerate(self.children):
            result.append(f'--- Child {idx + 1} monthly cost: {child.get_monthly_expense():.2f}$')

        result.append(f'--- Appliances monthly cost: {sum(a.get_monthly_expense() for a in self.appliances):.2f}$')

        return '\n'.join(result)
