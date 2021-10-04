delimiters = {"-", ",", ".", "!", "?"}


with open('text.txt', 'r') as input_file, open('output.txt', 'w') as output_file:
    for idx, line in enumerate(input_file):
        letters_count = 0
        punctuation_marks_count = 0

        for symbol in line:
            if symbol in delimiters:
                punctuation_marks_count += 1
            elif symbol.isalpha():
                letters_count += 1

        stripped_line = line.strip()

        output_file.write(f'Line {idx + 1}: {stripped_line} ({letters_count})({punctuation_marks_count})\n')

