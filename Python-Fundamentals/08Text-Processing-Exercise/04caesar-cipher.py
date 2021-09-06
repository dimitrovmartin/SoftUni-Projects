message = input()
crypt_message = ""

for char in message:
    crypt_ascii = ord(char) + 3
    crypt_char = chr(crypt_ascii)

    crypt_message += crypt_char

print(crypt_message)

