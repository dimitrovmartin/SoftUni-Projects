def make_bold(ref_func):
    def wrapper(*args):
        return f"<b>{ref_func(*args)}</b>"
    return wrapper


def make_italic(ref_func):
    def wrapper(*args):
        return f"<i>{ref_func(*args)}</i>"
    return wrapper


def make_underline(ref_func):
    def wrapper(*args):
        return f"<u>{ref_func(*args)}</u>"
    return wrapper


@make_bold
@make_italic
@make_underline
def greet(name):
    return f"Hello, {name}"


print(greet("Peter"))
