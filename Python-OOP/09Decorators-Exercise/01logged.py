def logged(ref_func):
    def wrapper(*args):
        result = ref_func(*args)

        return f"you called {ref_func.__name__}{args}\nit returned {result}"

    return wrapper


@logged
def func(*args):
    return 3 + len(args)
print(func(4, 4, 4))
