import unittest
from project.train.train import Train


class TrainTests(unittest.TestCase):
    def setUp(self):
        self.train = Train('vlak', 21)

    def test_init(self):
        self.assertEqual(self.train.name, 'vlak')
        self.assertEqual(self.train.capacity, 21)
        self.assertEqual(self.train.passengers, [])

    def test_add_raise_when_train_is_full(self):
        with self.assertRaises(ValueError) as ex:
            for _ in range(22):
                self.train.add(f'pesho{_}')

        self.assertEqual(str(ex.exception), 'Train is full')

    def test_add(self):
        result = self.train.add('pesho')

        self.assertEqual(result, 'Added passenger pesho')
        self.assertEqual(self.train.passengers[-1], 'pesho')

    def test_add_raises_when_passenger_exists(self):
        self.train.add('pesho')

        with self.assertRaises(ValueError) as ex:
            self.train.add('pesho')

        self.assertEqual(str(ex.exception), 'Passenger pesho Exists')

    def test_remove(self):
        self.train.add('pesho')
        result = self.train.remove('pesho')

        self.assertEqual(True, 'pesho' not in self.train.passengers)
        self.assertEqual(result, 'Removed pesho')

    def test_remove_raises(self):
        with self.assertRaises(ValueError) as ex:
            self.train.remove('pesho')

        self.assertEqual(str(ex.exception), 'Passenger Not Found')
