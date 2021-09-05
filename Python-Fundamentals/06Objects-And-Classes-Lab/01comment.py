class Comment:
    def __init__(self, username: str, content: str, likes: int = 0):
        self.username = username
        self.content = content
        self.likes = likes


comment = Comment("user1", "I like this book")
print(comment.username)
print(comment.content)
print(comment.likes)
