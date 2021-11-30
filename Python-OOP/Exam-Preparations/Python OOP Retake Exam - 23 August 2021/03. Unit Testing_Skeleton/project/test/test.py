import unittest

from project.library import Library


class LibraryTests(unittest.TestCase):
    def setUp(self):
        self.library = Library('Library')

    def test_init(self):
        self.assertEqual(self.library.name, 'Library')
        self.assertEqual(self.library.books_by_authors, {})
        self.assertEqual(self.library.readers, {})

    def test_set_name_throws_exception(self):
        with self.assertRaises(ValueError) as ex:
            library = Library('')

        self.assertEqual(str(ex.exception), 'Name cannot be empty string!')

    def test_add_book_if_author_not_in(self):
        self.library.add_book('Orwell', '1984')

        self.assertEqual(True, 'Orwell' in self.library.books_by_authors.keys())
        self.assertEqual(True, '1984' in self.library.books_by_authors['Orwell'])

    def test_add_book_if_author_in(self):
        self.library.add_book('Orwell', '1984')
        self.library.add_book('Orwell', 'Animal Farm')

        self.assertEqual(True, 'Orwell' in self.library.books_by_authors.keys())
        self.assertEqual(True, 'Animal Farm' in self.library.books_by_authors['Orwell'])

    def test_add_reader(self):
        self.library.add_reader('Pesho')

        self.assertEqual(True, 'Pesho' in self.library.readers.keys())

    def test_add_reader_if_reader_in(self):
        self.library.add_reader('Pesho')
        result = self.library.add_reader('Pesho')

        self.assertEqual(result, f"Pesho is already registered in the Library library.")

    def test_rent_book_if_reader_not_registered(self):
        result = self.library.rent_book('Pesho', 'Orwell', 'Animal Farm')

        self.assertEqual(result, f"Pesho is not registered in the Library Library.")

    def test_rent_book_if_author_not_in(self):
        self.library.add_reader('Pesho')
        result = self.library.rent_book('Pesho', 'Orwell', 'Animal Farm')
        self.assertEqual(result, f"Library Library does not have any Orwell's books.")

    def test_rent_book_if_book_not_in(self):
        self.library.add_reader('Pesho')
        self.library.add_book('Orwell', '1984')
        result = self.library.rent_book('Pesho', 'Orwell', 'Animal Farm')
        self.assertEqual(result, f"""Library Library does not have Orwell's "Animal Farm".""")

    def test_if_reader_rent_book_successfully(self):
        self.library.add_reader('Pesho')
        self.library.add_book('Orwell', '1984')
        self.library.rent_book('Pesho', 'Orwell', '1984')

        self.assertEqual([{'Orwell': '1984'}], self.library.readers['Pesho'])
        self.assertEqual([], self.library.books_by_authors['Orwell'])