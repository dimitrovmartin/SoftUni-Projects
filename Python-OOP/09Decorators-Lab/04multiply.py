def multiply(n):
    def decorator(ref_func):
        def wrapper(number):
            result = ref_func(number)
            return result * n

        return wrapper
    return decorator


@multiply(3)
def add_ten(number):
    return number + 10

print(add_ten(3))
