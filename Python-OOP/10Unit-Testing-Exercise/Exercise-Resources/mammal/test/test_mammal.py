import unittest
from project.mammal import Mammal


class MammalTests(unittest.TestCase):
    def setUp(self):
        self.mammal = Mammal('Sharo', 'Cat', 'Mquu')

    def test_init(self):
        self.assertEqual(self.mammal.name, 'Sharo')
        self.assertEqual(self.mammal.type, 'Cat')
        self.assertEqual(self.mammal.sound, 'Mquu')
        self.assertEqual(self.mammal._Mammal__kingdom, 'animals')

    def test_make_sound(self):
        self.assertEqual(self.mammal.make_sound(), f"{self.mammal.name} makes {self.mammal.sound}")

    def test_get_kingdom(self):
        self.assertEqual(self.mammal.get_kingdom(), 'animals')

    def test_info(self):
        self.assertEqual(self.mammal.info(), f"{self.mammal.name} is of type {self.mammal.type}")
