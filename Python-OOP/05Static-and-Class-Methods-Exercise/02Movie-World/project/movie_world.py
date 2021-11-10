class MovieWorld:
    def __init__(self, name):
        self.name = name
        self.customers = []
        self.dvds = []

    @staticmethod
    def dvd_capacity():
        return 15

    @staticmethod
    def customer_capacity():
        return 10

    def add_customer(self, customer):
        if len(self.customers) == self.customer_capacity():
            return

        self.customers.append(customer)

    def add_dvd(self, dvd):
        if len(self.dvds) == self.dvd_capacity():
            return

        self.dvds.append(dvd)

    def rent_dvd(self, customer_id, dvd_id):
        customer = self.__find_object(customer_id, self.customers)
        dvd = self.__find_object(dvd_id, self.dvds)

        if not dvd:
            return

        if dvd in customer.rented_dvds:
            return f'{customer.name} has already rented {dvd.name}'

        if dvd.is_rented:
            return 'DVD is already rented'

        if customer.age < dvd.age_restriction:
            return f"{customer.name} should be at least {dvd.age_restriction} to rent this movie"

        customer.rented_dvds.append(dvd)
        dvd.is_rented = True

        return f"{customer.name} has successfully rented {dvd.name}"

    def return_dvd(self, customer_id, dvd_id):
        customer = self.__find_object(customer_id, self.customers)
        dvd = self.__find_object(dvd_id, self.dvds)

        if not dvd:
            return

        if dvd not in customer.rented_dvds:
            return f"{customer.name} does not have that DVD"

        customer.rented_dvds.remove(dvd)
        dvd.is_rented = False

        return f"{customer.name} has successfully returned {dvd.name}"

    def __repr__(self):
        customer_info = '\n'.join(str(x) for x in self.customers)
        dvd_info = '\n'.join(str(x) for x in self.dvds)

        return customer_info + '\n' + dvd_info

    @staticmethod
    def __find_object(_id, objects):
        obj = [x for x in objects if x.id == _id]
        return obj[0] if obj else None
