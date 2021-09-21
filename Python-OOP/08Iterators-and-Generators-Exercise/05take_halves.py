def solution():
    def integers():
        current_number = 1

        while True:
            yield current_number
            current_number += 1

    def halves():
        for i in integers():
            yield i / 2

    def take(n, seq):
        ll = []
        counter = 0

        for el in seq:
            if counter == n:
                break
            else:
                ll.append(el)
                counter += 1

        return ll

    return take, halves, integers


take = solution()[0]
halves = solution()[1]
print(take(5, halves()))
