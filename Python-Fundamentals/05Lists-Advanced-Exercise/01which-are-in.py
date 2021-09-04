first_list = input().split(", ")
second_list = input().split(", ")

contained_words = []

for first_word in first_list:
    for second_word in second_list:
        if first_word in second_word and first_word not in contained_words:
            contained_words.append(first_word)

print(contained_words)
