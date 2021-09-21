class sequence_repeat:
    def __init__(self, sequence, count):
        self.sequence = sequence
        self.count = count
        self.index = 0

    def __iter__(self):
        return self

    def __next__(self):
        if not self.count == 0:
            if self.index >= len(self.sequence):
                self.index = 0

            current_index = self.index
            self.index += 1
            self.count -= 1

            return self.sequence[current_index]
        else:
            raise StopIteration

result = sequence_repeat('abc', 5)
for item in result:
    print(item, end ='')
