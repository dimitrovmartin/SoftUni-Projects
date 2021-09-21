def number_increment(numbers):
    def increase():
        return [number + 1 for number in numbers]
    return increase()


print(number_increment([1, 2, 3]))