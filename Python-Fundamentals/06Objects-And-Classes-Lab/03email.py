class Email:
    def __init__(self, sender: str, receiver: str, content: str):
        self.sender = sender
        self.receiver = receiver
        self.content = content
        self.is_sent = False

    def send(self):
        self.is_sent = True

    def get_info(self):
        return f"{self.sender} says to {self.receiver}: {self.content}. Sent: {self.is_sent}"


emails = []

line = input()

while not line == "Stop":
    sender, receiver, content = line.split()

    email = Email(sender, receiver, content)
    emails.append(email)

    line = input()

indexes = [int(i) for i in input().split(", ")]

for i in indexes:
    emails[i].is_sent = True

for email in emails:
    print(email.get_info())


