substring_to_remove = input()
word = input()

while substring_to_remove in word:
    word = word.replace(substring_to_remove, "")

print(word)
