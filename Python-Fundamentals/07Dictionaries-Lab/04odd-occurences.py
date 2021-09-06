words_by_count = {}

words = input().split()

for word in words:
    word_to_lower = word.lower()

    if word_to_lower in words_by_count.keys():
        words_by_count[word_to_lower] += 1
    else:
        words_by_count[word_to_lower] = 1

filtered_words_by_count = [kvp[0] for kvp in words_by_count.items() if not kvp[1] % 2 == 0]

print(" ".join(filtered_words_by_count))
