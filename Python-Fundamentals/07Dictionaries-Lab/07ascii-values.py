characters_by_ascii_values = {}

line = input().split(", ")

for char in line:
    characters_by_ascii_values[char] = ord(char)

print(characters_by_ascii_values)