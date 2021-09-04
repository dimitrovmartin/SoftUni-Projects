word = input()

vowels = ["a", "e", "o", "u", "i"]

filtered_word = [symbol for symbol in word if symbol.lower() not in vowels]

print("".join(filtered_word))