words = input().split()
searched_word = input()

words = [word for word in words if word == word[::-1]]
searched_word_count = words.count(searched_word)

print(words)
print(f"Found palindrome {searched_word_count} times")
