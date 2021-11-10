class Gym:
    def __init__(self):
        self.customers = []
        self.trainers = []
        self.equipment = []
        self.plans = []
        self.subscriptions = []

    def add_customer(self, customer):
        self.__add_object(customer, self.customers)

    def add_trainer(self, trainer):
        self.__add_object(trainer, self.trainers)

    def add_equipment(self, equipment):
        self.__add_object(equipment, self.equipment)

    def add_plan(self, plan):
        self.__add_object(plan, self.plans)

    def add_subscription(self, subscription):
        self.__add_object(subscription, self.subscriptions)

    def subscription_info(self, subscription_id):
        subscription = self.__find_object_by_id(subscription_id, self.subscriptions)
        customer = self.__find_object_by_id(subscription.customer_id, self.customers)
        trainer = self.__find_object_by_id(subscription.trainer_id, self.trainers)
        plan = self.__find_object_by_id(subscription.exercise_id, self.plans)
        equipment = self.__find_object_by_id(plan.equipment_id, self.equipment)

        return str(subscription) + '\n' + str(customer) + '\n' + str(trainer) + '\n' + str(equipment) + '\n' + str(plan)

    @staticmethod
    def __find_object_by_id(_id, objects):
        obj = [x for x in objects if x.id == _id]
        return obj[0] if obj else None

    @staticmethod
    def __add_object(obj, objects):
        if obj not in objects:
            objects.append(obj)
