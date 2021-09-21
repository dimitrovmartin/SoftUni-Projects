def type_check(t):
    def decorator(ref_func):
        def wrapper(num):
            if type(num) == t:
                return ref_func(num)
            else:
                return "Bad Type"
        return wrapper
    return decorator


@type_check(int)
def times2(num):
    return num*2
print(times2(2))
print(times2('Not A Number'))
