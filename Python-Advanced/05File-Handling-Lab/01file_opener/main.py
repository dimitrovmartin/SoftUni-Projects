try:
    file = open('text.txt', 'r').close()
except FileNotFoundError:
    print('File not found')
else:
    print('File found')