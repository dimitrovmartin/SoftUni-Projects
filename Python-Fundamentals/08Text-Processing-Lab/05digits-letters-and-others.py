word = input()

digits = ""
letters = ""
others = ""

for char in word:
    if char.isalpha():
        letters += char
    elif char.isdigit():
        digits += char
    else:
        others += char

print(digits)
print(letters)
print(others)
