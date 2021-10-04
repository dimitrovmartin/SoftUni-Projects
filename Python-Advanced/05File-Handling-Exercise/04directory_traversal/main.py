import os

directory = os.getcwd()
path = os. walk(directory)

dictionary = {}

for root, directories, files in path:
    for file in files:
        file_parts = file.split('.')

        if len(file_parts) == 1:
            continue

        extension = '.' + file.split('.')[1]

        if extension in dictionary:
            dictionary[extension].append(file)
        else:
            dictionary[extension] = []

dictionary = dict(sorted(dictionary.items()))

for key, value in dictionary.items():
    print(key)

    sorted_list = sorted(value)
    for file_name in sorted_list:
        print(f'- - - {file_name}')