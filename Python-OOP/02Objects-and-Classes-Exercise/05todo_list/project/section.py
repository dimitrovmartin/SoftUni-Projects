from project.task import Task


class Section:
    def __init__(self, name):
        self.name = name
        self.tasks = []

    def add_task(self, task: Task):
        if task in self.tasks:
            return f'Task is already in the section {self.name}'

        self.tasks.append(task)
        return f'Task {task.details()} is added to the section'

    def complete_task(self, task_name):
        for task in self.tasks:
            if task.name == task_name:
                task.completed = True
                return f'Completed task {task_name}'

        return f'Could not find task with the name {task_name}'

    def clean_section(self):
        tasks_count = len(self.tasks)
        self.tasks = [task for task in self.tasks if not task.completed]

        return f'Cleared {tasks_count - len(self.tasks)} tasks.'

    def view_section(self):
        details = [f'Section {self.name}:']
        [details.append(task.details()) for task in self.tasks]
        return '\n'.join(details)
