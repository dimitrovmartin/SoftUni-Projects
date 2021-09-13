import re

try:
    with open("words.txt", "r") as words_file:
        with open("input.txt", "r") as input_file:
            searched_words = words_file.read().split()
            input_words = input_file.read().lower()
            input_words = re.findall(r'[a-z\']+', input_words)

            words_by_count = {}

            for word in searched_words:
                count = input_words.count(word)
                words_by_count[word] = count

            words_by_count = sorted(words_by_count.items(), key=lambda x: -x[1])
            print(*[f'{tup[0]} - {tup[1]}' for tup in words_by_count], sep='\n')

except FileNotFoundError:
    print("File not found!")