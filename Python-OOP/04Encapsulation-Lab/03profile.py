class Profile:
    def __init__(self, username, password):
        self.username = username
        self.password = password

    @property
    def username(self):
        return self.__username

    @username.setter
    def username(self, value):
        if 5 <= len(value) <= 15:
            self.__username = value
        else:
            raise ValueError("The username must be between 5 and 15 characters.")

    @property
    def password(self):
        return self.__password

    @password.setter
    def password(self, value):
        if self.__is_valid_password(value):
            self.__password = value
        else:
            raise ValueError("The password must be 8 or more characters with at least 1 digit and 1 uppercase letter.")

    def __is_valid_password(self, value):
        if len(value) >= 8 and self.__contains_digit(value) and self.__contains_uppercase(value):
            return True
        else:
            return False

    @staticmethod
    def __contains_digit(value):
        for char in value:
            if char.isdigit():
                return True

        return False

    @staticmethod
    def __contains_uppercase(value):
        for char in value:
            if char.isupper():
                return True

        return False

    def __str__(self):
        return f'You have a profile with username: "{self.username}" and password: {"*" * len(self.password)}'


correct_profile = Profile("Username", "Passw0rd")
print(correct_profile)
