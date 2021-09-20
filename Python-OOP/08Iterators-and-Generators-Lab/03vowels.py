class vowels:
    def __init__(self, text):
        self.text = text
        self.vowels = "AEOUIYaeouiy"
        self.text_vowels = [el for el in self.text if el in self.vowels]
        self.start = 0
        self.end = len(self.text_vowels) - 1

    def __iter__(self):
        return self

    def __next__(self):
        if self.start > self.end:
            raise StopIteration
        else:
            current_el = self.text_vowels[self.start]
            self.start += 1
            return current_el


my_string = vowels('Abcedifuty0o')
for char in my_string:
    print(char)
