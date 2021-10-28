class Programmer:
    def __init__(self, name, language, skills):
        self.name = name
        self.language = language
        self.skills = skills

    def watch_course(self, course, language,earned_skills):
        if not language == self.language:
            return f"{self.name} does not know {language}"

        self.skills += earned_skills
        return f"{self.name} watched {course}"

    def change_language(self, new_language, skills_needed):
        if self.language == new_language:
            return f"{self.name} already knows {new_language}"
        if self.skills < skills_needed:
            return f"{self.name} needs {skills_needed - self.skills} more skills"

        previous_language = self.language
        self.language = new_language
        return f"{self.name} switched from {previous_language} to {new_language}"


programmer = Programmer("John", "Java", 50)
print(programmer.watch_course("Python Masterclass", "Python", 84))
print(programmer.change_language("Java", 30))
print(programmer.change_language("Python", 100))
print(programmer.watch_course("Java: zero to hero", "Java", 50))
print(programmer.change_language("Python", 100))
print(programmer.watch_course("Python Masterclass", "Python", 84))
