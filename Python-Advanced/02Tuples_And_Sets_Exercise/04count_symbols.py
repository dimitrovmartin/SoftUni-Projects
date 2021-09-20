text = input()

symbols_by_count = {}

for char in text:
    if char not in symbols_by_count.keys():
        symbols_by_count[char] = 0

    symbols_by_count[char] += 1

symbols_by_count = (sorted(symbols_by_count.items()))

for key, value in symbols_by_count:
    print(f"{key}: {value} time/s")


