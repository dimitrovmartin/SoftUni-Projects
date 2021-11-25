from extended_list import IntegerList

import unittest


class IntegerListTests(unittest.TestCase):
    def setUp(self):
        self.list = IntegerList(1, 2, 3, 4, 5)

    def test_add_item(self):
        self.list.add(5)

        self.assertEqual(self.list._IntegerList__data[-1], 5)

    def test_add_item_raises_exception_when_item_is_not_an_integer(self):
        with self.assertRaises(ValueError) as ex:
            self.list.add('pesho')

        self.assertEqual(str(ex.exception), "Element is not Integer")

    def test_remove_item(self):
        element = self.list._IntegerList__data[2]
        self.list.remove_index(2)

        self.assertEqual(4, self.list._IntegerList__data[2])

    def test_remove_item_raises_when_index_is_invalid(self):
        with self.assertRaises(IndexError) as ex:
            self.list.remove_index(10)

        self.assertEqual(str(ex.exception), "Index is out of range")

    def test_get(self):
        self.assertEqual(self.list.get(0), 1)

    def test_add_item_raises_exception_when_index_is_invalid(self):
        with self.assertRaises(IndexError) as ex:
            self.list.get(10)

        self.assertEqual(str(ex.exception), "Index is out of range")

    def test_insert(self):
        self.list.insert(3, 20)
        self.assertEqual(self.list.get(3), 20)

    def test_insert_item_raises_exception_when_index_is_invalid(self):
        with self.assertRaises(IndexError) as ex:
            self.list.insert(10, 20)

        self.assertEqual(str(ex.exception), "Index is out of range")

    def test_insert_item_raises_exception_when_item_is_not_an_integer(self):
        with self.assertRaises(ValueError) as ex:
            self.list.insert(2, "20")

        self.assertEqual(str(ex.exception), "Element is not Integer")

    def test_get_biggest(self):
        self.assertEqual(self.list.get_biggest(), 5)

    def test_get_index(self):
        self.assertEqual(self.list.get_index(1), 0)


if __name__ == "__main__":
    unittest.main()
