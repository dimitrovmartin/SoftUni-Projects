def tags(tag):
    def decorator(ref_func):
        def wrapper(*args):
            return f"<{tag}>{ref_func(*args)}</{tag}>"
        return wrapper
    return decorator


@tags('p')
def join_strings(*args):
    return "".join(args)
print(join_strings("Hello", " you!"))
