from fibonacci_helper import create_seq, locate


while True:
    command = input().split()
    action = command[0]
    if action == "Stop":
        break
    number = int(command[-1])
    if action == "Create":
        seq = create_seq(number)
        print(' '.join(map(str, seq)))
    elif action == "Locate":
        print(locate(number))