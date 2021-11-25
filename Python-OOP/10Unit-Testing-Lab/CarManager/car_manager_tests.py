import unittest
from car_manager import Car


class CarManagerTests(unittest.TestCase):
    def setUp(self):
        self.car = Car('Volkswagen', 'Golf', 10, 30)

    def test_init(self):
        self.assertEqual(self.car.make, 'Volkswagen')
        self.assertEqual(self.car.model, 'Golf')
        self.assertEqual(self.car.fuel_consumption, 10)
        self.assertEqual(self.car.fuel_capacity, 30)

    def test_make_raises_exception_if_its_null_or_empty(self):
        with self.assertRaises(Exception) as ex:
            self.car.make = ''

        self.assertEqual(str(ex.exception), "Make cannot be null or empty!")

        with self.assertRaises(Exception) as ex:
            self.car.make = None

        self.assertEqual(str(ex.exception), "Make cannot be null or empty!")

    def test_model_raises_exception_if_its_null_or_empty(self):
        with self.assertRaises(Exception) as ex:
            self.car.model = ''

        self.assertEqual(str(ex.exception), "Model cannot be null or empty!")

        with self.assertRaises(Exception) as ex:
            self.car.model = None

        self.assertEqual(str(ex.exception), "Model cannot be null or empty!")

    def test_fuel_consumption_raises_exception_if_is_zero_or_negative(self):
        with self.assertRaises(Exception) as ex:
            self.car.fuel_consumption = 0

        self.assertEqual(str(ex.exception), "Fuel consumption cannot be zero or negative!")

        with self.assertRaises(Exception) as ex:
            self.car.fuel_consumption = -1

        self.assertEqual(str(ex.exception), "Fuel consumption cannot be zero or negative!")

    def test_fuel_capacity_raises_exception_if_is_zero_or_negative(self):
        with self.assertRaises(Exception) as ex:
            self.car.fuel_capacity = 0

        self.assertEqual(str(ex.exception), "Fuel capacity cannot be zero or negative!")

        with self.assertRaises(Exception) as ex:
            self.car.fuel_capacity = -1

        self.assertEqual(str(ex.exception), "Fuel capacity cannot be zero or negative!")

    def test_fuel_amount_raises_exception_if_is_negative(self):
        with self.assertRaises(Exception) as ex:
            self.car.fuel_amount = -1

        self.assertEqual(str(ex.exception), "Fuel amount cannot be negative!")

    def test_refuel(self):
        self.car.refuel(5)
        self.assertEqual(self.car.fuel_amount, 5)
        self.car.refuel(31)
        self.assertEqual(self.car.fuel_amount, 30)

    def test_refuel_raises_if_fuel_is_zero_or_negative(self):
        with self.assertRaises(Exception) as ex:
            self.car.refuel(0)

        self.assertEqual(str(ex.exception), "Fuel amount cannot be zero or negative!")

        with self.assertRaises(Exception) as ex:
            self.car.refuel(-1)

        self.assertEqual(str(ex.exception), "Fuel amount cannot be zero or negative!")

    def test_drive(self):
        self.car.fuel_amount = 10
        needed = (2 / 100) * self.car.fuel_consumption
        fuel_now = self.car.fuel_amount
        self.car.drive(2)

        self.assertEqual(self.car.fuel_amount, fuel_now - needed)

    def test_drive_raises_if_fuel_is_not_enough_to_drive(self):
        with self.assertRaises(Exception) as ex:
            self.car.drive(2)

        self.assertEqual(str(ex.exception), "You don't have enough fuel to drive!")


if __name__ == "__main__":
    unittest.main()
