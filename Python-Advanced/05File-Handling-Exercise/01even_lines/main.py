delimiters = {"-", ",", ".", "!", "?"}

with open('text.txt', 'r') as file:
    for idx, line in enumerate(file):

        if idx % 2 == 0:
            replaced_line = line

            for delimiter in delimiters:
                replaced_line = replaced_line.replace(delimiter, '@')

            reversed_line = ' '.join(replaced_line.split()[::-1])
            print(reversed_line)

