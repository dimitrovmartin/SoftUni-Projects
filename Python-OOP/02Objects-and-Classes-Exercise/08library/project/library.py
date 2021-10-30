class Library:
    def __init__(self):
        self.user_records = []
        self.books_available = {}
        self.rented_books = {}

    def add_user(self, user):
        if user in self.user_records:
            return f'User with id = {user.user_id} already registered in the library!'

        self.user_records.append(user)

    def remove_user(self, user):
        if user not in self.user_records:
            return 'We could not find such user to remove!'

        self.user_records.remove(user)

    def change_username(self, user_id, new_username):
        for user in self.user_records:
            if user.user_id == user_id:
                if user.username == new_username:
                    return f'Please check again the provided username - it should be different than the username used so far!'

                user.username = new_username
                return f'Username successfully changed to: {new_username} for userid: {user_id}'

        return f'There is no user with id = {user_id}!'
