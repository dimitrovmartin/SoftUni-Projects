def vowel_filter(ref_func):
    def wrapper():
        letters = ref_func()
        vowels = "aeoui"

        return [letter for letter in letters if letter.lower() in vowels]
    return wrapper


@vowel_filter
def get_letters():
    return ["a", "b", "c", "d", "e"]

print(get_letters())
