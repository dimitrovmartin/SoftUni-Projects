def even_parameters(ref_func):
    def wrapper(*args):
        try:
            for arg in args:
                if arg % 2 != 0:
                    return "Please use only even numbers!"
        except:
            return "Please use only even numbers!"

        return ref_func(*args)
    return wrapper


@even_parameters
def add(a, b):
    return a + b

print(add(2, 4))
print(add("Peter", 1))
