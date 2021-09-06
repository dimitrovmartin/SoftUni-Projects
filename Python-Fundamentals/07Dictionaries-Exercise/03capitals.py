countries = input().split(", ")
capitals = input().split(", ")

capitals_by_countries = dict(zip(countries, capitals))

for key, value in capitals_by_countries.items():
    print(f"{key} -> {value}")
