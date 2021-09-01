year = int(input())
is_happy_year = False

while not is_happy_year:
    year += 1

    year_as_string = str(year)
    year_string_length = len(year_as_string)
    year_set_length = len(set(year_as_string))

    if year_string_length == year_set_length:
        break

print(year)
