words_by_synonyms = {}

n = int(input())

for _ in range(n):
    word = input()
    synonym = input()

    if word not in words_by_synonyms.keys():
        words_by_synonyms[word] = []

    words_by_synonyms[word].append(synonym)

for key, value in words_by_synonyms.items():
    print(f"{key} - {', '.join(value)}")