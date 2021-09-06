dictionary = {}

line = input()

while not line == "statistics":
    key, value = line.split(": ")
    if key in dictionary.keys():
        dictionary[key] += int(value)
    else:
        dictionary[key] = int(value)

    line = input()

total_products = len(dictionary)
total_quantity = sum(dictionary.values())

print("Products in stock:")

for key, value in dictionary.items():
    print(f"- {key}: {value}")

print(f"Total Products: {total_products}")
print(f"Total Quantity: {total_quantity}")