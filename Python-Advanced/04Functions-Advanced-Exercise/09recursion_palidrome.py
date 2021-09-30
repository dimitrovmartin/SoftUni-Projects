def palindrome(text, idx):
    if len(text) // 2 == idx:
        return f'{text} is a palindrome'

    if not text[idx] == text[len(text) - idx - 1]:
       return f'{text} is not a palindrome'

    return palindrome(text, idx + 1)


print(palindrome("abcba", 0))
print(palindrome("peter", 0))