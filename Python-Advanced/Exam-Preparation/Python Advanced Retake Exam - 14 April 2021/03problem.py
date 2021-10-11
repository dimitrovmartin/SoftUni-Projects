def flights(*args):
    flights_data = {}

    for i in range(0, len(args), + 2):
        name = args[i]

        if name == 'Finish':
            return flights_data

        km = int(args[i + 1])

        if name in flights_data.keys():
            flights_data[name] += km
        else:
            flights_data[name] = km


print(flights('Vienna', 256, 'Vienna', 26, 'Morocco', 98, 'Paris', 115, 'Finish', 'Paris', 15))
print(flights('London', 0, 'New York', 9, 'Aberdeen', 215, 'Sydney', 2, 'New York', 300, 'Nice', 0, 'Finish'))
print(flights('Finish', 'New York', 90, 'Aberdeen', 300, 'Sydney', 0))