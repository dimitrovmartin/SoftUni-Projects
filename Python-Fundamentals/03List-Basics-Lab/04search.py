n = int(input())
searched_word = input()

texts = []
texts_with_searched_word = []

for _ in range(n):
    text = input()

    texts.append(text)

    if searched_word in text:
        texts_with_searched_word.append(text)

print(texts)
print(texts_with_searched_word)

