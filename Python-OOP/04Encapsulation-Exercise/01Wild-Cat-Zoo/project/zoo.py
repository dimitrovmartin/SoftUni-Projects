class Zoo:
    def __init__(self, name, budget, animal_capacity, workers_capacity):
        self.name = name
        self.__budget = budget
        self.__animal_capacity = animal_capacity
        self.__workers_capacity = workers_capacity
        self.animals = []
        self.workers = []

    def add_animal(self, animal, price):
        if len(self.animals) == self.__animal_capacity:
            return 'Not enough space for animal'

        if self.__budget < price:
            return 'Not enough budget'

        self.__budget -= price
        self.animals.append(animal)
        return f'{animal.name} the {animal.__class__.__name__} added to the zoo'

    def hire_worker(self, worker):
        if len(self.workers) == self.__workers_capacity:
            return 'Not enough space for worker'

        self.workers.append(worker)
        return f'{worker.name} the {worker.__class__.__name__} hired successfully'

    def fire_worker(self, worker_name):
        for worker in self.workers:
            if worker.name == worker_name:
                self.workers.remove(worker)
                return f'{worker_name} fired successfully'

        return f'There is no {worker_name} in the zoo'

    def pay_workers(self):
        workers_salaries = [worker.salary for worker in self.workers]
        salaries_sum = sum(workers_salaries)

        if self.__budget < salaries_sum:
            return 'You have no budget to pay your workers. They are unhappy'

        self.__budget -= salaries_sum
        return f'You payed your workers. They are happy. Budget left: {self.__budget}'

    def tend_animals(self):
        animals_money_for_care = [animal.money_for_care for animal in self.animals]
        money_for_care_sum = sum(animals_money_for_care)

        if self.__budget < money_for_care_sum:
            return 'You have no budget to tend the animals. They are unhappy.'

        self.__budget -= money_for_care_sum
        return f'You tended all the animals. They are happy. Budget left: {self.__budget}'

    def profit(self, amount):
        self.__budget += amount

    def animals_status(self):
        lions = [str(animal) for animal in self.animals if animal.__class__.__name__ == 'Lion']
        tigers = [str(animal) for animal in self.animals if animal.__class__.__name__ == 'Tiger']
        cheetahs = [str(animal) for animal in self.animals if animal.__class__.__name__ == 'Cheetah']

        animals_status = []

        animals_status.append(f'You have {len(self.animals)} animals')
        animals_status.append(f'----- {len(lions)} Lions:')
        animals_status.append('\n'.join(lions))
        animals_status.append(f'----- {len(tigers)} Tigers:')
        animals_status.append('\n'.join(tigers))
        animals_status.append(f'----- {len(cheetahs)} Cheetahs:')
        animals_status.append('\n'.join(cheetahs))

        return '\n'.join(animals_status)

    def workers_status(self):
        keepers = [str(worker) for worker in self.workers if worker.__class__.__name__ == 'Keeper']
        caretakers = [str(worker) for worker in self.workers if worker.__class__.__name__ == 'Caretaker']
        vets = [str(worker) for worker in self.workers if worker.__class__.__name__ == 'Vet']

        workers_status = []

        workers_status.append(f'You have {len(self.workers)} workers')
        workers_status.append(f'----- {len(keepers)} Keepers:')
        workers_status.append('\n'.join(keepers))
        workers_status.append(f'----- {len(caretakers)} Caretakers:')
        workers_status.append('\n'.join(caretakers))
        workers_status.append(f'----- {len(vets)} Vets:')
        workers_status.append('\n'.join(vets))

        return '\n'.join(workers_status)
