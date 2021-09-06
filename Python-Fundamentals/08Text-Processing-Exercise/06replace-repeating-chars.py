word = input()

previous_char = None
filtered_word = []

for char in word:
    if not char == previous_char:
        filtered_word.append(char)

    previous_char = char

print("".join(filtered_word))