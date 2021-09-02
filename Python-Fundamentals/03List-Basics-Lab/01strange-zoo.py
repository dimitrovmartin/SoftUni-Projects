tail = input()
body = input()
head = input()

meerkat = [tail, body, head]

meerkat[2], meerkat[0] = meerkat[0], meerkat[2]

print(meerkat)
