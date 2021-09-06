strings = input().split()

result = ''

for word in strings:
    result += word * len(word)

print(result)