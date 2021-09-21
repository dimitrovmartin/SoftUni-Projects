def even_numbers(ref_func):
    def wrapper(numbers):
        numbers = ref_func(numbers)

        return [number for number in numbers if number % 2 == 0]
    return wrapper


@even_numbers
def get_numbers(numbers):
    return numbers

print(get_numbers([1, 2, 3, 4, 5]))
