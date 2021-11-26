import unittest

from project.vehicle import Vehicle


class VehicleTests(unittest.TestCase):
    def setUp(self):
        self.vehicle = Vehicle(30, 120)

    def test_init(self):
        self.assertEqual(self.vehicle.fuel, 30)
        self.assertEqual(self.vehicle.capacity, self.vehicle.fuel)
        self.assertEqual(self.vehicle.horse_power, 120)
        self.assertEqual(self.vehicle.fuel_consumption, 1.25)

    def test_drive(self):
        fuel_needed = self.vehicle.fuel_consumption * 3
        fuel_after_drive = self.vehicle.fuel - fuel_needed
        self.vehicle.drive(3)

        self.assertEqual(self.vehicle.fuel, fuel_after_drive)

    def test_drive_raises(self):
        with self.assertRaises(Exception) as ex:
            self.vehicle.drive(31)

        self.assertEqual(str(ex.exception), 'Not enough fuel')

    def test_refuel(self):
        self.vehicle.fuel = 10
        self.vehicle.refuel(10)

        self.assertEqual(self.vehicle.fuel, 20)

    def test_refuel_raises(self):
        with self.assertRaises(Exception) as ex:
            self.vehicle.refuel(10)

        self.assertEqual(str(ex.exception), "Too much fuel")

    def test_str(self):
        self.assertEqual(str(self.vehicle),
                         f"The vehicle has {self.vehicle.horse_power} horse power with {self.vehicle.fuel} fuel left and {self.vehicle.fuel_consumption} fuel consumption")
