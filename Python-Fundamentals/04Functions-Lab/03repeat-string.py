def get_repeated_string(string, times):
    return string * times


word = input()
repeat_times = int(input())

repeated_string = get_repeated_string(word,repeat_times)

print(repeated_string)

