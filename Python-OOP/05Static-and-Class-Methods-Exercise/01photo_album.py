from math import ceil


class PhotoAlbum:
    PHOTOS_PER_PAGE = 4

    def __init__(self, pages):
        self.pages = pages
        self.photos = [[] for _ in range(pages)]

    @classmethod
    def from_photos_count(cls, photos_count):
        return cls(ceil(photos_count / cls.PHOTOS_PER_PAGE))

    def add_photo(self, label):
        for idx, row in enumerate(self.photos):
            if not len(row) == self.PHOTOS_PER_PAGE:
                row.append(label)
                return f'{label} photo added successfully on page {idx + 1} slot {len(row)}'
        return 'No more free slots'

    def display(self):
        separator = '-----------'
        result = ''
        result += separator + '\n'

        for row in self.photos:
            result += ('[] ' * len(row)).rstrip() + '\n'
            result += separator + '\n'

        return result.rstrip()

album = PhotoAlbum(2)

print(album.add_photo("baby"))
print(album.add_photo("first grade"))
print(album.add_photo("eight grade"))
print(album.add_photo("party with friends"))
print(album.photos)
print(album.add_photo("prom"))
print(album.add_photo("wedding"))

print(album.display())
