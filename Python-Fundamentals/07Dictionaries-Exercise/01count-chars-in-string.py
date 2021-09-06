chars_by_count = {}

word = input()

for char in word:
    if not char == " ":
        if char in chars_by_count:
            chars_by_count[char] += 1
        else:
            chars_by_count[char] = 1

for key, value in chars_by_count.items():
    print(f"{key} -> {value}")
