def age_assignment(*args, **kwargs):
    result = {}

    for name in args:
        first_letter = name[0]
        age = kwargs[first_letter]

        result[name] = age

    return result


print(age_assignment("Amy", "Bill", "Willy", W=36, A=22, B=61))
