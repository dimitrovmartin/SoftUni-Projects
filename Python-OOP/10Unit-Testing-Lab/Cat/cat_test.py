from cat import Cat
import unittest


class CatsTest(unittest.TestCase):
    def setUp(self):
        self.cat = Cat('Sharo')

    def test_init(self):
        self.assertEqual(self.cat.name, 'Sharo')

    def test_cat_is_fed_after_eating(self):
        self.cat.eat()

        self.assertEqual(self.cat.fed, True)

    def test_cat_size_increase_after_eating(self):
        self.cat.eat()

        self.assertEqual(self.cat.size, 1)

    def test_cat_eat_raises_exception_if_cat_is_fed(self):
        self.cat.eat()

        with self.assertRaises(Exception) as ex:
            self.cat.eat()

        self.assertEqual(str(ex.exception), 'Already fed.')

    def test_cat_not_sleepy_after_sleep(self):
        self.cat.eat()
        self.cat.sleep()

        self.assertEqual(self.cat.sleepy, False)

    def test_cat_eat_raises_exception_if_cat_is_not_sleepy(self):
        with self.assertRaises(Exception) as ex:
            self.cat.sleep()

        self.assertEqual(str(ex.exception), 'Cannot sleep while hungry')


if __name__ == '__main__':
    unittest.main()