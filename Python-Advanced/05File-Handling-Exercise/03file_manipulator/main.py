import os

ERROR_MESSAGE = "An error occurred"

line = input()

while not line == 'End':
    command_data = line.split('-')
    command = command_data[0]
    file_name = command_data[1]

    if command == 'Create':
        file = open(file_name, 'w').close()
    elif command == 'Add':
        content = command_data[2]

        with open(file_name, 'a') as file:
            file.write(content + "\n")
    elif command == 'Replace':
        old_string = command_data[2]
        new_string = command_data[3]

        if os.path.exists(file_name):
            with open(file_name, 'r') as file:
                content = file.read()
                content = content.replace(old_string, new_string)
                with open(file_name, 'w') as writing_file:
                    writing_file.write(content + '\n')
        else:
            print(ERROR_MESSAGE)
    elif command == 'Delete':
        if os.path.exists(file_name):
            os.remove(file_name)
        else:
            print(ERROR_MESSAGE)

    line = input()

