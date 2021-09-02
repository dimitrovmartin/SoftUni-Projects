first_word = input()
second_word = input()
last_word = first_word

for i in range(len(first_word)):
    first_part = second_word[:i + 1]
    second_part = first_word[i + 1:]
    current_word = first_part + second_part

    if not current_word == last_word:
        print(current_word)

    last_word = current_word
